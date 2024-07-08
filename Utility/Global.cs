using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Web.UI;
using System.Data;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Reflection;
using System.Text.RegularExpressions;

namespace AllenLibrary.Utility
{
    public class Global : System.Web.UI.Page
    {
        #region Global Messages
        public const string ErrorMsg = "There is some problem occurs, Please try again or contact IT & Automation for assistance.";
        public const string NotFoundMsg = "The search key was not found in any record.";
        public const string PasswordPolicy = "The Password you typed does not meet the password policy requirements. Check the minimum password length, password complexity and password history requirements.";
        #endregion

        #region Cryptography
        private static string ByteArrayToHexString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        private static byte[] HexStringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        #region MD5Encrypt
        public static string MD5Encrypt(string sPassword)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bs = System.Text.Encoding.UTF8.GetBytes(sPassword);
            bs = x.ComputeHash(bs);
            System.Text.StringBuilder s = new System.Text.StringBuilder();
            foreach (byte b in bs)
            {
                s.Append(b.ToString("x2").ToUpper());
            }

            return s.ToString();
        }
        #endregion

        #region EncryptDecrypt3
        public static string Encrypt3(string strText)
        {
            return Encrypt3Detail(strText, "&%#@?,:*");
        }

        public static string Decrypt3(string strText)
        {
            strText = strText.Replace(" ", "+");
            return Decrypt3Detail(strText, "&%#@?,:*");
        }

        private static string Encrypt3Detail(string strText, string strEncrKey)
        {
            byte[] byKey;
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };

            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private static string Decrypt3Detail(string strText, string sDecrKey)
        {
            byte[] byKey;
            byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };

            byte[] inputByteArray;
            // inputByteArray.Length = strText.Length;

            try
            {
                byKey = System.Text.Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(System.Web.HttpUtility.UrlDecode(strText));
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = System.Text.Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        #endregion

        #region EncryptDecrypt Number
        public string EncryptNumber(string input)
        {
            return Server.UrlEncode(Encrypt3(input));
        }

        public string DecryptNumber(string input)
        {
            return Decrypt3(input);
        }
        #endregion

        #region Encryption Cross-platform
        public RijndaelManaged GetRijndaelManaged(String secretKey)
        {
            var keyBytes = new byte[16];
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);
            Array.Copy(secretKeyBytes, keyBytes, Math.Min(keyBytes.Length, secretKeyBytes.Length));
            return new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 128,
                BlockSize = 128,
                Key = keyBytes,
                IV = keyBytes
            };
        }

        public byte[] Encrypt(byte[] plainBytes, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateEncryptor()
                .TransformFinalBlock(plainBytes, 0, plainBytes.Length);
        }

        public byte[] Decrypt(byte[] encryptedData, RijndaelManaged rijndaelManaged)
        {
            return rijndaelManaged.CreateDecryptor()
                .TransformFinalBlock(encryptedData, 0, encryptedData.Length);
        }

        /// <summary>
        /// Encrypts plaintext using AES 128bit key and a Chain Block Cipher and returns a base64 encoded string
        /// </summary>
        /// <param name="plainText">Plain text to encrypt</param>
        /// <param name="key">Secret key</param>
        /// <returns>Base64 encoded string</returns>
        public String Encrypt(String plainText, String key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Server.UrlEncode(Convert.ToBase64String(Encrypt(plainBytes, GetRijndaelManaged(key))));
        }

        /// <summary>
        /// Decrypts a base64 encoded string using the given key (AES 128bit key and a Chain Block Cipher)
        /// </summary>
        /// <param name="encryptedText">Base64 Encoded String</param>
        /// <param name="key">Secret Key</param>
        /// <returns>Decrypted String</returns>
        public String Decrypt(String encryptedText, String key)
        {
            var encryptedBytes = Convert.FromBase64String(System.Web.HttpUtility.UrlDecode((encryptedText)));
            return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(key)));
        }

        /// <summary>
        /// Encrypts plaintext using AES 128bit key and a Chain Block Cipher and returns a Hex encoded string
        /// </summary>
        /// <param name="plainText">Plain text to encrypt</param>
        /// <param name="key">Secret key</param>
        /// <returns>Hex encoded string</returns>
        public String EncryptHex(String plainText, String key)
        {
            var plainBytes = Encoding.UTF8.GetBytes(plainText);
            return Server.UrlEncode(ByteArrayToHexString(Encrypt(plainBytes, GetRijndaelManaged(key))));
        }

        /// <summary>
        /// Decrypts a Hex encoded string using the given key (AES 128bit key and a Chain Block Cipher)
        /// </summary>
        /// <param name="encryptedText">Hex Encoded String</param>
        /// <param name="key">Secret Key</param>
        /// <returns>Decrypted String</returns>
        public String DecryptHex(String encryptedText, String key)
        {
            var encryptedBytes = HexStringToByteArray(System.Web.HttpUtility.UrlDecode((encryptedText)));
            return Encoding.UTF8.GetString(Decrypt(encryptedBytes, GetRijndaelManaged(key)));
        }
        #endregion
        #endregion

        #region File Exists Or Not
        public bool FileExistsOrNot(string path)
        {
            bool exist = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(path);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    exist = response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
            }
            return exist;
        }
        #endregion

        #region GetOTP
        public string GetOTP()
        {
            var chars = "0123456789";
            var stringChars = new char[4];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            string finalString = new String(stringChars);
            return finalString;
        }
        #endregion

        #region NumbersToWords
        public string NumbersToWords(int inputNumber)
        {
            int inputNo = inputNumber;

            if (inputNo == 0)
                return "Zero";

            int[] numbers = new int[4];
            int first = 0;
            int u, h, t;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            if (inputNo < 0)
            {
                sb.Append("Minus ");
                inputNo = -inputNo;
            }

            string[] words0 = {"" ,"One ", "Two ", "Three ", "Four ",
            "Five " ,"Six ", "Seven ", "Eight ", "Nine "};
            string[] words1 = {"Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ",
            "Fifteen ","Sixteen ","Seventeen ","Eighteen ", "Nineteen "};
            string[] words2 = {"Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ",
            "Seventy ","Eighty ", "Ninety "};
            string[] words3 = { "Thousand ", "Lakh ", "Crore " };

            numbers[0] = inputNo % 1000; // units
            numbers[1] = inputNo / 1000;
            numbers[2] = inputNo / 100000;
            numbers[1] = numbers[1] - 100 * numbers[2]; // thousands
            numbers[3] = inputNo / 10000000; // crores
            numbers[2] = numbers[2] - 100 * numbers[3]; // lakhs

            for (int i = 3; i > 0; i--)
            {
                if (numbers[i] != 0)
                {
                    first = i;
                    break;
                }
            }
            for (int i = first; i >= 0; i--)
            {
                if (numbers[i] == 0) continue;
                u = numbers[i] % 10; // ones
                t = numbers[i] / 10;
                h = numbers[i] / 100; // hundreds
                t = t - 10 * h; // tens
                if (h > 0) sb.Append(words0[h] + "Hundred ");
                if (u > 0 || t > 0)
                {
                    if (h > 0 || i == 0) sb.Append("and ");
                    if (t == 0)
                        sb.Append(words0[u]);
                    else if (t == 1)
                        sb.Append(words1[u]);
                    else
                        sb.Append(words2[t - 2] + words0[u]);
                }
                if (i != 0) sb.Append(words3[i - 1]);
            }
            return sb.ToString().TrimEnd().ToUpper() + " ONLY";
        }
        #endregion

        #region GetWebServiceData
        public DataSet GetWebServiceData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)
                      WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream resStream = response.GetResponseStream();
            string tempString = null;
            int count = 0;

            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            do
            {
                count = resStream.Read(buf, 0, buf.Length);
                if (count != 0)
                {
                    tempString = Encoding.ASCII.GetString(buf, 0, count);

                    sb.Append(tempString);
                }
            }
            while (count > 0);
            System.Diagnostics.Debug.Write(sb.ToString());

            DataSet ds = JsonConvert.DeserializeObject<DataSet>(sb.ToString());

            return ds;
        }
        #endregion

        #region GetIP
        public string GetIP()
        {
            string strHostName = "";
            strHostName = System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(strHostName);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();

        }

        protected string GetRemoteIPAddress()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }
        #endregion

        #region Response Redirect With POST Request
        /// <summary>
        /// POST data and Redirect to the specified url using the specified page.
        /// </summary>
        /// <param name="page">The page which will be the referrer page.</param>
        /// <param name="destinationUrl">The destination Url to which
        /// the post and redirection is occuring.</param>
        /// <param name="data">The data should be posted.</param>
        public static void RedirectAndPOST(Page page, string destinationUrl, NameValueCollection data)
        {
            //Prepare the Posting form
            string strForm = PreparePOSTForm(destinationUrl, data);
            //Add a literal control the specified page holding 
            //the Post Form, this is to submit the Posting form with the request.
            page.Controls.Add(new LiteralControl(strForm));
        }

        /// <summary>
        /// This method prepares an Html form which holds all data
        /// in hidden field in the addetion to form submitting script.
        /// </summary>
        /// <param name="url">The destination Url to which the post and redirection
        /// will occur, the Url can be in the same App or ouside the App.</param>
        /// <param name="data">A collection of data that
        /// will be posted to the destination Url.</param>
        /// <returns>Returns a string representation of the Posting form.</returns>
        private static String PreparePOSTForm(string url, NameValueCollection data)
        {
            //Set a name for the form
            string formID = "PostForm";
            //Build the form using the specified data to be posted.
            StringBuilder strForm = new StringBuilder();
            strForm.Append("<form id=\"" + formID + "\" name=\"" +
                           formID + "\" action=\"" + url +
                           "\" method=\"POST\">");

            foreach (string key in data)
            {
                strForm.Append("<input type=\"hidden\" name=\"" + key +
                               "\" value=\"" + data[key] + "\">");
            }

            strForm.Append("</form>");
            //Build the JavaScript which will do the Posting operation.
            StringBuilder strScript = new StringBuilder();
            strScript.Append("<script language='javascript'>");
            strScript.Append("var v" + formID + " = document." +
                             formID + ";");
            strScript.Append("v" + formID + ".submit();");
            strScript.Append("</script>");
            //Return the form and the script concatenated.
            //(The order is important, Form then JavaScript)
            return strForm.ToString() + strScript.ToString();
        }


        //NameValueCollection data = new NameValueCollection();
        //data.Add("v1", "val1");
        //data.Add("v2", "val2");
        //HttpHelper.RedirectAndPOST(this.Page, "http://DestUrl/Default.aspx", data);
        #endregion

        #region Format
        public Int32 GetValueOrZero(string valueAsString)
        {
            Int32 a = 0;
            Int32.TryParse(valueAsString, out a);
            return a;
        }
        public string GetValueOrDecimal(string valueAsString)
        {
            Double a = 0.00;
            Double.TryParse(valueAsString, out a);
            return String.Format("{0:0.00}", a);
        }
        public string ReplaceZeroWithEmpty(string valueAsString)
        {
            valueAsString = GetValueOrEmptyOrZero(valueAsString, false);
            return (valueAsString == "0" ? "" : valueAsString);
        }
        public string GetValueOrEmptyOrZero(string valueAsString, bool IsZero)
        {
            return (String.IsNullOrEmpty(valueAsString) ? (IsZero ? "0" : "") : valueAsString);
        }

        public static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        public string ToRoman(int number)
        {
            if ((number < 0) || (number > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
            if (number < 1) return string.Empty;
            if (number >= 1000) return "M" + ToRoman(number - 1000);
            if (number >= 900) return "CM" + ToRoman(number - 900); //EDIT: i've typed 400 instead 900
            if (number >= 500) return "D" + ToRoman(number - 500);
            if (number >= 400) return "CD" + ToRoman(number - 400);
            if (number >= 100) return "C" + ToRoman(number - 100);
            if (number >= 90) return "XC" + ToRoman(number - 90);
            if (number >= 50) return "L" + ToRoman(number - 50);
            if (number >= 40) return "XL" + ToRoman(number - 40);
            if (number >= 10) return "X" + ToRoman(number - 10);
            if (number >= 9) return "IX" + ToRoman(number - 9);
            if (number >= 5) return "V" + ToRoman(number - 5);
            if (number >= 4) return "IV" + ToRoman(number - 4);
            if (number >= 1) return "I" + ToRoman(number - 1);
            throw new ArgumentOutOfRangeException("something bad happened");
        }

        public string Capitalize(string input)
        {
            return System.Globalization.CultureInfo.CurrentUICulture.TextInfo.ToTitleCase(input.Trim().ToLower());
        }

        public string MakeValidFileName(string name)
        {
            string invalidChars = Regex.Escape(new string(System.IO.Path.GetInvalidFileNameChars()));
            string invalidReStr = string.Format(@"[{0}]+", invalidChars);
            string replace = Regex.Replace(name, invalidReStr, "_").Replace(";", "").Replace(",", "");
            return replace;
        }

        public string HorizontalAlign(string value)
        {
            Int64 ck = 0;
            var c = (Int64.TryParse(value, out ck) ? "plr ctr" : "plr");
            return c;
        }

        public string AddOrdinal(int num)
        {
            if (num <= 0) return num.ToString();

            switch (num % 100)
            {
                case 11:
                case 12:
                case 13:
                    return num + "th";
            }

            switch (num % 10)
            {
                case 1:
                    return num + "st";
                case 2:
                    return num + "nd";
                case 3:
                    return num + "rd";
                default:
                    return num + "th";
            }
        }

        public string firstName(string Name)
        {
            if (Name.Split(' ').Length > 0)
                return ValidateInputData.CheckSQL(Name.Split(' ')[0]);
            else
                return "";
        }

        public string lastName(string Name)
        {
            if (Name.Split(' ').Length > 1)
                return ValidateInputData.CheckSQL(Name.Split(new[] { ' ' }, 2)[1]);
            else
                return "";
        }
        #endregion



        #region Gender
        public string Gender(string input)
        {
            return input.ToUpper() == "M" ? "MALE" : input.ToUpper() == "F" ? "FEMALE" : "NOT AVAILABLE";

        }
        #endregion

        #region medium
        public string medium(string input)
        {
            return input.ToUpper() == "E" ? "ENGLISH" : input.ToUpper() == "H" ? "HINDI" : input.ToUpper() == "ENGLISH" ? "ENGLISH" : input.ToUpper() == "HINDI" ? "HINDI" : "NOT AVAILABLE";

        }
        #endregion

        #region Database
        public DataTable AddAutoIncrement(DataTable dt)
        {
            if (dt == null)
                return dt;

            dt = Remove(dt, "S.No.");

            DataTable dtIncremented = new DataTable(dt.TableName);
            DataColumn dc = new DataColumn("S.No.");
            dc.AutoIncrement = true;
            dc.AutoIncrementSeed = 1;
            dc.AutoIncrementStep = 1;
            dc.DataType = typeof(int);

            dtIncremented.Columns.Add(dc);
            dtIncremented.BeginLoadData();

            DataTableReader dtReader = new DataTableReader(dt);
            dtIncremented.Load(dtReader);
            dtIncremented.EndLoadData();
            return dtIncremented;
        }

        public DataTable Capitalize(DataTable dt)
        {
            if (dt != null)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName.ToUpper() == "EMAIL")
                        Lower(dt, "EMAIL");
                    else if (col.DataType == typeof(string))
                        dt.AsEnumerable().ToList().ForEach(row => row[col.ColumnName] = Capitalize(row[col.ColumnName].ToString()));
                }
            }

            return dt;
        }
        public DataTable Capitalize(DataTable dt, string[] columnName)
        {
            if (columnName.Length > 0 && dt != null)
            {
                foreach (string str in columnName)
                {
                    if (dt.Columns.Contains(str))
                        dt.AsEnumerable().ToList().ForEach(row => row[str] = Capitalize(row[str].ToString()));
                }
            }

            return dt;
        }
        public DataTable Capitalize(DataTable dt, string columnName)
        {
            if (dt != null)
            {
                if (dt.Columns.Contains(columnName))
                    dt.AsEnumerable().ToList().ForEach(row => row[columnName] = Capitalize(row[columnName].ToString()));
            }

            return dt;
        }
        public DataTable Upper(DataTable dt, string columnName)
        {
            if (dt != null)
            {
                if (dt.Columns.Contains(columnName))
                    dt.AsEnumerable().ToList().ForEach(row => row[columnName] = row[columnName].ToString().ToUpper());
            }

            return dt;
        }
        public static DataSet upperColumn(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
                for (int i = 0; i < ds.Tables.Count; i++)
                    if (ds.Tables[i] != null)
                        for (int j = 0; j < ds.Tables[i].Columns.Count; j++)
                            ds.Tables[i].Columns[j].ColumnName = ds.Tables[i].Columns[j].ColumnName.ToUpper();

            return ds;
        }
        public DataTable Lower(DataTable dt, string columnName)
        {
            if (dt != null)
            {
                if (dt.Columns.Contains(columnName))
                    dt.AsEnumerable().ToList().ForEach(row => row[columnName] = row[columnName].ToString().ToLower());
            }

            return dt;
        }
        public static DataSet lowerColumn(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
                for (int i = 0; i < ds.Tables.Count; i++)
                    if (ds.Tables[i] != null)
                        for (int j = 0; j < ds.Tables[i].Columns.Count; j++)
                            ds.Tables[i].Columns[j].ColumnName = ds.Tables[i].Columns[j].ColumnName.ToLower();

            return ds;
        }

        public DataTable Remove(DataTable dt, string[] columnName)
        {
            if (columnName.Length > 0 && dt != null)
            {
                foreach (string str in columnName)
                {
                    if (dt.Columns.Contains(str)) { dt.Columns.Remove(str); }
                }
            }

            return dt;
        }
        public DataTable Remove(DataTable dt, string columnName)
        {
            if (dt != null)
            {
                if (dt.Columns.Contains(columnName)) { dt.Columns.Remove(columnName); }
            }

            return dt;
        }
        public DataTable Remove(DataTable dt1, DataTable dt2, string colName)
        {
            try
            {
                DataView dv = new DataView(dt2);
                DataTable dtNot = dv.ToTable(true, colName);
                var prod = dtNot.AsEnumerable().ToDictionary(p => p[colName].ToString().ToUpper());
                var query = from imp in dt1.AsEnumerable()
                            where !prod.ContainsKey(imp[colName].ToString().ToUpper())
                            select imp;

                return query.CopyToDataTable();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public DataTable Replace(DataTable dt, string oldColumnName, string newColumnName)
        {
            if (dt == null)
                return dt;

            if (dt.Columns.Contains(oldColumnName))
                dt.Columns[oldColumnName].ColumnName = newColumnName;

            return dt;
        }
        public DataTable Replace(DataTable dt, Dictionary<string, string> colName)
        {
            if (dt == null || colName == null)
                return dt;

            foreach (var item in colName)
            {
                if (dt.Columns.Contains(item.Key))
                    dt.Columns[item.Key].ColumnName = item.Value;
            }

            return dt;
        }

        public DataTable ChangeDataType(DataTable dt, Type type, string[] columnName)
        {
            if (dt == null || type == null || columnName == null)
                return dt;

            //clone datatable     
            DataTable dtCloned = dt.Clone();
            foreach (string str in columnName)
            {
                if (dtCloned.Columns.Contains(str))
                    //change data type of column
                    dtCloned.Columns[str].DataType = type;
            }
            //import row to cloned datatable
            foreach (DataRow row1 in dt.Rows)
            {
                dtCloned.ImportRow(row1);
            }
            dt = dtCloned;

            return dt;
        }
        public DataTable ChangeDataType(DataTable dt, Type type, string columnName)
        {
            if (dt == null || type == null)
                return dt;

            //clone datatable     
            DataTable dtCloned = dt.Clone();
            if (dtCloned.Columns.Contains(columnName))
                //change data type of column
                dtCloned.Columns[columnName].DataType = type;
            //import row to cloned datatable
            foreach (DataRow row1 in dt.Rows)
            {
                dtCloned.ImportRow(row1);
            }
            dt = dtCloned;

            return dt;
        }

        public Int32 Sum(DataTable dt, string columnName)
        {
            Int32 a = 0;

            if (dt != null && dt.Columns.Contains(columnName))
            {
                return dt.AsEnumerable()
                    .Where(r => !r.IsNull(columnName) && Int32.TryParse(r[columnName].ToString(), out a))
                    .Sum(r => a);
            }

            return 0;
        }

        public static DataTable ConvertToDataTable<T>(IEnumerable<T> varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (T rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;
                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }
                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }

                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        #region Paging
        public string PageItem(DataTable dt)
        {
            var pageitem = "10";
            int count = dt.Rows.Count;
            if (count > 10)
                pageitem += ",20";
            if (count > 20)
                pageitem += ",50";
            if (count > 50)
                pageitem += ",100";
            if (count > 100)
                pageitem += ",200";
            if (count > 200)
                pageitem += ",500";
            if (count > 500)
                pageitem += ",1000";
            if (count > 1000)
                pageitem += ",5000";
            if (count > 5000)
                pageitem += ",10000";

            return pageitem;
        }
        #endregion

        #region JSON
        public DataTable toDataTable(string json)
        {
            var result = new DataTable();
            var jArray = Newtonsoft.Json.Linq.JArray.Parse(json);
            //Initialize the columns, If you know the row type, replace this   
            foreach (var row in jArray)
            {
                foreach (var jToken in row)
                {
                    var jproperty = jToken as Newtonsoft.Json.Linq.JProperty;
                    if (jproperty == null) continue;
                    if (result.Columns[jproperty.Name] == null)
                        result.Columns.Add(jproperty.Name, typeof(string));
                }
            }
            foreach (var row in jArray)
            {
                var datarow = result.NewRow();
                foreach (var jToken in row)
                {
                    var jProperty = jToken as Newtonsoft.Json.Linq.JProperty;
                    if (jProperty == null) continue;
                    datarow[jProperty.Name] = jProperty.Value.ToString();
                }
                result.Rows.Add(datarow);
            }

            return result;
        }
        #endregion
        #endregion


    }
}
