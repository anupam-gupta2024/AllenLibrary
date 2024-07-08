using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.Threading;
using iTextSharp.text;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Data.OleDb;

namespace AllenLibrary.Utility
{
    public class Excel
    {
        public static string ExcelColumnFromNumber(int column)
        {
            string columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                decimal currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }

        public static void FormatAsTable(Microsoft.Office.Interop.Excel.Range SourceRange, string TableName, string TableStyleName)
        {
            SourceRange.Worksheet.ListObjects.Add(Microsoft.Office.Interop.Excel.XlListObjectSourceType.xlSrcRange,
            SourceRange, System.Type.Missing, Microsoft.Office.Interop.Excel.XlYesNoGuess.xlYes, System.Type.Missing).Name =
                TableName;
            SourceRange.Select();
            SourceRange.Worksheet.ListObjects[TableName].TableStyle = TableStyleName;
        }

        public static void XLSX(DataTable dt, string filename)
        {
            if (dt != null)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                Microsoft.Office.Interop.Excel.Application xlApp = null;
                Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
                Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;
                object misValue = System.Reflection.Missing.Value;
                try
                {
                    xlApp = new Microsoft.Office.Interop.Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        xlWorkSheet.Cells[1, i + 1] = dt.Columns[i].ToString();
                    }
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            xlWorkSheet.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                        }
                    }
                    xlApp.Columns.AutoFit();

                    Microsoft.Office.Interop.Excel.Range range = xlWorkSheet.get_Range("A1", ExcelColumnFromNumber(dt.Columns.Count) + (dt.Rows.Count + 1).ToString() + "");
                    FormatAsTable(range, "Table1", "TableStyleLight9");

                    saveDlg = new System.Windows.Forms.SaveFileDialog();
                    saveDlg.Filter = "Excel files (*.xlsx)|*.xlsx";
                    saveDlg.FilterIndex = 0;
                    saveDlg.RestoreDirectory = true;
                    saveDlg.Title = "Export Excel File To";
                    if (filename.Trim() != "")
                        saveDlg.FileName = filename.Replace("-", "_").Replace(" ", "_").Replace("/", "_").Replace(":", "_").Trim();
                    else
                        saveDlg.FileName = DateTime.Now.ToString().Replace("-", "_").Replace(" ", "_").Replace("/", "_").Replace(":", "_").Trim();

                    if (DialogResult.OK == (new Invoker(saveDlg).Invoke()))
                    {
                        string loc = saveDlg.FileName;
                        xlWorkBook.SaveCopyAs(loc);
                        xlWorkBook.Saved = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Marshal.ReleaseComObject(xlWorkSheet);
                    xlWorkBook.Close(true, misValue, misValue);
                    Marshal.ReleaseComObject(xlWorkBook);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlApp);
                    xlApp = null;
                }
            }
        }

        public static void XLS(DataTable dt, string filename)
        {
            if (dt != null)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                Microsoft.Office.Interop.Excel.Application oexcel = null;
                Microsoft.Office.Interop.Excel.Workbook obook = null;
                Microsoft.Office.Interop.Excel._Worksheet osheet = null;
                object misValue = System.Reflection.Missing.Value;
                try
                {
                    /*Set up work book, work sheets, and excel application*/
                    oexcel = new Microsoft.Office.Interop.Excel.Application();

                    string path = AppDomain.CurrentDomain.BaseDirectory;
                    obook = oexcel.Workbooks.Add(misValue);
                    osheet = new Microsoft.Office.Interop.Excel.Worksheet();

                    //  obook.Worksheets.Add(misValue);
                    osheet = (Microsoft.Office.Interop.Excel.Worksheet)obook.Sheets["Sheet1"];
                    int colIndex = 0;
                    int rowIndex = 1;

                    foreach (DataColumn dc in dt.Columns)
                    {
                        colIndex++;
                        osheet.Cells[1, colIndex] = dc.ColumnName;
                    }
                    foreach (DataRow dr in dt.Rows)
                    {
                        rowIndex++;
                        colIndex = 0;

                        foreach (DataColumn dc in dt.Columns)
                        {
                            colIndex++;
                            osheet.Cells[rowIndex, colIndex] = dr[dc.ColumnName];
                        }
                    }
                    osheet.Columns.AutoFit();

                    Microsoft.Office.Interop.Excel.Range range = osheet.get_Range("A1", ExcelColumnFromNumber(dt.Columns.Count) + (1).ToString() + "");
                    range.Font.Bold = true;
                    range.Interior.ColorIndex = 47;
                    range.Font.ColorIndex = 2;

                    Microsoft.Office.Interop.Excel.Range range1 = osheet.get_Range("A1", ExcelColumnFromNumber(dt.Columns.Count) + (dt.Rows.Count + 1).ToString() + "");
                    range1.Borders.ColorIndex = 15;

                    saveDlg = new System.Windows.Forms.SaveFileDialog();
                    saveDlg.Filter = "Excel files (*.xls)|*.xls";
                    saveDlg.FilterIndex = 0;
                    saveDlg.RestoreDirectory = true;
                    saveDlg.Title = "Export Excel File To";
                    if (filename.Trim() != "")
                        saveDlg.FileName = filename.Replace("-", "_").Replace(" ", "_").Replace("/", "_").Replace(":", "_").Trim();
                    else
                        saveDlg.FileName = DateTime.Now.ToString().Replace("-", "_").Replace(" ", "_").Replace("/", "_").Replace(":", "_").Trim();

                    if (DialogResult.OK == (new Invoker(saveDlg).Invoke()))
                    {
                        string loc = saveDlg.FileName;

                        //Release and terminate excel
                        obook.SaveAs(loc, Microsoft.Office.Interop.Excel.XlFileFormat.xlExcel8, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    obook.Close(true, misValue, misValue);
                    oexcel.Quit();
                    Marshal.ReleaseComObject(osheet);
                    Marshal.ReleaseComObject(obook);
                    Marshal.ReleaseComObject(oexcel);
                    GC.Collect();
                }
            }
        }

        public static void BulkXLSX(DataSet ds, string filename)
        {
            if (ds != null)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveDlg.FilterIndex = 0;
                saveDlg.RestoreDirectory = true;
                saveDlg.Title = "Export Excel File To";
                if (filename.Trim() != "")
                    saveDlg.FileName = filename.Replace("-", "_").Replace(" ", "_").Replace("/", "_").Replace(":", "_").Trim();
                else
                    saveDlg.FileName = DateTime.Now.ToString().Replace("-", "_").Replace(" ", "_").Replace("/", "_").Replace(":", "_").Trim();

                if (DialogResult.OK == (new Invoker(saveDlg).Invoke()))
                {
                    string destination = saveDlg.FileName;

                    using (var workbook = SpreadsheetDocument.Create(destination, DocumentFormat.OpenXml.SpreadsheetDocumentType.Workbook))
                    {
                        var workbookPart = workbook.AddWorkbookPart();

                        workbook.WorkbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                        workbook.WorkbookPart.Workbook.Sheets = new DocumentFormat.OpenXml.Spreadsheet.Sheets();

                        foreach (System.Data.DataTable table in ds.Tables)
                        {

                            var sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                            var sheetData = new DocumentFormat.OpenXml.Spreadsheet.SheetData();
                            sheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet(sheetData);

                            DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<DocumentFormat.OpenXml.Spreadsheet.Sheets>();
                            string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                            uint sheetId = 1;
                            if (sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Count() > 0)
                            {
                                sheetId =
                                    sheets.Elements<DocumentFormat.OpenXml.Spreadsheet.Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                            }

                            DocumentFormat.OpenXml.Spreadsheet.Sheet sheet = new DocumentFormat.OpenXml.Spreadsheet.Sheet() { Id = relationshipId, SheetId = sheetId, Name = table.TableName };
                            sheets.Append(sheet);

                            DocumentFormat.OpenXml.Spreadsheet.Row headerRow = new DocumentFormat.OpenXml.Spreadsheet.Row();

                            List<String> columns = new List<string>();
                            foreach (System.Data.DataColumn column in table.Columns)
                            {
                                columns.Add(column.ColumnName);

                                DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(column.ColumnName);
                                headerRow.AppendChild(cell);
                            }


                            sheetData.AppendChild(headerRow);

                            foreach (System.Data.DataRow dsrow in table.Rows)
                            {
                                DocumentFormat.OpenXml.Spreadsheet.Row newRow = new DocumentFormat.OpenXml.Spreadsheet.Row();
                                foreach (String col in columns)
                                {
                                    DocumentFormat.OpenXml.Spreadsheet.Cell cell = new DocumentFormat.OpenXml.Spreadsheet.Cell();
                                    cell.DataType = DocumentFormat.OpenXml.Spreadsheet.CellValues.String;
                                    cell.CellValue = new DocumentFormat.OpenXml.Spreadsheet.CellValue(dsrow[col].ToString()); //
                                    newRow.AppendChild(cell);
                                }

                                sheetData.AppendChild(newRow);
                            }

                        }
                    }
                }
            }
        }

        public static void BulkCSV(DataTable dt, string filename)
        {
            if (dt != null)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();
                saveDlg.Filter = "Excel files (*.csv)|*.csv";
                saveDlg.FilterIndex = 0;
                saveDlg.RestoreDirectory = true;
                saveDlg.Title = "Export Excel File To";
                if (filename.Trim() != "")
                    saveDlg.FileName = filename.Replace("-", "_").Replace(" ", "_").Replace("/", "_").Replace(":", "_").Trim();
                else
                    saveDlg.FileName = DateTime.Now.ToString().Replace("-", "_").Replace(" ", "_").Replace("/", "_").Replace(":", "_").Trim();

                if (DialogResult.OK == (new Invoker(saveDlg).Invoke()))
                {
                    string destination = saveDlg.FileName;

                    ToCSV(dt, destination);
                }
            }
        }

        public static void ToCSV(DataTable dtDataTable, string strFilePath)
        {
            StreamWriter sw = new StreamWriter(strFilePath, false);
            //headers  
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = String.Format("\"{0}\"",
                                System.Text.RegularExpressions.Regex.Replace(
                                    value, @"[\""]", "", System.Text.RegularExpressions.RegexOptions.None
                                    ));
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        public static string ExportToCSVFile(DataTable dtTable)
        {
            StringBuilder sbldr = new StringBuilder();
            if (dtTable.Columns.Count != 0)
            {
                foreach (DataColumn col in dtTable.Columns)
                {
                    sbldr.Append(col.ColumnName + ',');
                }
                sbldr.Append("\r\n");
                foreach (DataRow row in dtTable.Rows)
                {
                    foreach (DataColumn column in dtTable.Columns)
                    {
                        string value = row[column].ToString();

                        if (value.Contains("\""))
                        {
                            value = System.Text.RegularExpressions.Regex.Replace(value, @"[\""]", "", System.Text.RegularExpressions.RegexOptions.None);
                        }

                        value = value.Contains(",")
                                       ? string.Format("\"{0}\"", value)
                                       : value;

                        sbldr.Append(value + ',');
                    }
                    sbldr.Append("\r\n");
                }
            }
            return sbldr.ToString();
        }

        public DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            DataTable dt = new DataTable();
            using (StreamReader sr = new StreamReader(strFilePath))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    if (rows.Length > 0)
                    {
                        DataRow dr = dt.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dr[i] = rows[i].Trim();
                        }
                        dt.Rows.Add(dr);
                    }
                }

            }


            return dt;
        }

        public DataTable ConvertXSLXtoDataTable(string strFilePath, string connString, string sheetname)
        {
            OleDbConnection oledbConn = new OleDbConnection(connString);
            DataTable dt = new DataTable();
            try
            {

                oledbConn.Open();
                using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetname + "]", oledbConn))
                {
                    OleDbDataAdapter oleda = new OleDbDataAdapter();
                    oleda.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    oleda.Fill(ds);

                    dt = ds.Tables[0];
                }
            }
            catch
            {
            }
            finally
            {

                oledbConn.Close();
            }

            return dt;

        }
    }

    public class Invoker
    {
        public CommonDialog InvokeDialog;
        private Thread InvokeThread;
        private DialogResult InvokeResult;

        public Invoker(CommonDialog dialog)
        {
            InvokeDialog = dialog;
            InvokeThread = new Thread(new ThreadStart(InvokeMethod));
            InvokeThread.SetApartmentState(ApartmentState.STA);
            InvokeResult = DialogResult.None;
        }

        public DialogResult Invoke()
        {
            InvokeThread.Start();
            InvokeThread.Join();
            return InvokeResult;
        }

        private void InvokeMethod()
        {
            InvokeResult = InvokeDialog.ShowDialog();

        }
    }
}
