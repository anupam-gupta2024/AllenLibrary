using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AllenLibrary.Utility
{
    public class ValidateInputData
    {
        public static bool checkForSQLInjection(string userInput)
        {
            bool isSQLInjection = false;

            string[] sqlCheckList = {"--",";--",";","/*","*/","@@","char","nchar","varchar","nvarchar","alter","begin",
                                      "cast","create","cursor","declare","delete","drop","end","exec","execute",
                                      "fetch","insert","kill","open","select","sys","sysobjects","syscolumns","table","update"
                                    };

            string CheckString = userInput.Replace("'", "''");
            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    isSQLInjection = true;
                }
            }
            return isSQLInjection;
        }


        public static bool checkForSQLInjectionbasic(string userInput)
        {
            bool isSQLInjection = false;

            string[] sqlCheckList = {"--",";--",";","/*","*/","@@","char","nchar","varchar","nvarchar","alter","begin",
                                      "cast","create","cursor","declare","delete","drop","exec","execute",
                                      "fetch","insert","kill","open","select","sys","sysobjects","syscolumns","table","update"
                                    };

            string CheckString = userInput.Replace("'", "''");
            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) >= 0))
                {
                    isSQLInjection = true;
                }
            }
            return isSQLInjection;
        }


        public string SafeSqlLiteral(System.Object theValue, System.Object theLevel)
        {

            // Written by Sunil Kumar Choudhary

            // intLevel represent how thorough the value will be checked for dangerous code
            // intLevel (1) - Do just the basic. This level will already counter most of the SQL injection attacks
            // intLevel (2) -   (non breaking space) will be added to most words used in SQL queries to prevent unauthorized access to the database. Safe to be printed back into HTML code. Don't use for usernames or passwords

            string strValue = (string)theValue;
            int intLevel = (int)theLevel;

            if (strValue != null)
            {
                if (intLevel > 0)
                {
                    strValue = strValue.Replace("'", "''"); // Most important one! This line alone can prevent most injection attacks
                    strValue = strValue.Replace("--", "");
                    strValue = strValue.Replace("[", "[[]");
                    strValue = strValue.Replace("%", "[%]");
                }
                if (intLevel > 1)
                {
                    string[] myArray = new string[] { "xp_ ", "update ", "insert ", "select ", "drop ", "alter ", "create ", "rename ", "delete ", "replace " };
                    int i = 0;
                    int i2 = 0;
                    int intLenghtLeft = 0;
                    for (i = 0; i < myArray.Length; i++)
                    {
                        string strWord = myArray[i];
                        Regex rx = new Regex(strWord, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                        MatchCollection matches = rx.Matches(strValue);
                        i2 = 0;
                        foreach (Match match in matches)
                        {
                            GroupCollection groups = match.Groups;
                            intLenghtLeft = groups[0].Index + myArray[i].Length + i2;
                            strValue = strValue.Substring(0, intLenghtLeft - 1) + "&nbsp;" + strValue.Substring(strValue.Length - (strValue.Length - intLenghtLeft), strValue.Length - intLenghtLeft);
                            i2 += 5;
                        }
                    }
                }
                return strValue;
            }
            else
            {
                return strValue;
            }
        }
        public static bool ValidateGrade(string Value, out string Message)
        {
            char[] Val = Value.Trim().ToUpper().ToCharArray();

            if (Val.Length > 0)
            {
                int intAscii = (int)Val[0];
                if (intAscii == 65 || intAscii == 66 || intAscii == 67 || intAscii == 68 || intAscii == 69)
                {
                    if (Val.Length > 1)
                    {
                        intAscii = (int)Val[1];
                        if (intAscii == 49 || intAscii == 50 || intAscii == 43)
                        {
                            if (Val.Length > 2)
                            {
                                Message = "Enter valid grade like A1,A2,A+,...";
                                return false;
                            }
                            else
                            {
                                Message = "Valid grade";
                                return true;
                            }
                        }
                        else
                        {

                            Message = "Enter valid grade like A1,A2,A+,...";
                            return false;
                        }
                    }
                    else
                    {

                        Message = "Valid grade";
                        return true;
                    }
                }
                else
                {
                    if (ValidatePercentage(Value, true))
                    {
                        if ((int)float.Parse(Value) <= 100)
                        {

                            Message = "Valie grade";
                            return true;
                        }
                        else
                        {

                            Message = "Your percentage must be <=100";
                            return false;
                        }
                    }
                    else
                    {

                        Message = "Please enter correct grade or percentage";
                        return false;
                    }
                }

            }
            else
            {

                Message = "Please enter your grade or percentage";
                return false;
            }
        }
        public static bool ValidatePercentage(string Value, bool iscomp)
        {
            char[] Val = Value.Replace(".", "").ToCharArray();

            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii < 48 || intAscii > 57)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool ValidateValue(string Value, bool iscomp)
        {
            char[] Val = Value.ToCharArray();
            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii != 32)
                {
                    if (intAscii < 65 || intAscii > 90)
                    {
                        return false;
                    }
                }
            }
            if (iscomp)
            {
                return CheckCompulsory(Value);
            }
            return true;
        }
        public static bool ValidateNormalText(string Value, bool iscomp)
        {
            Value = Value.ToUpper().Replace(" ", "").Replace("'", "").Replace("-", "").Replace(".", "");
            char[] Val = Value.ToCharArray();
            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii > 90 || intAscii < 65)
                {
                    return false;
                }
            }
            if (iscomp)
            {
                return CheckCompulsory(Value);
            }
            return true;
        }
        public static bool ValidateAddress(string Value, bool iscomp)
        {
            Value = Value.ToUpper().Replace(" ", "").Replace("'", "").Replace("-", "").Replace(".", "").Replace("/", "").Replace(",", "").Replace(":", "").Replace("#", "");
            char[] Val = Value.ToCharArray();
            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii > 90 || intAscii < 48)
                {
                    return false;
                }
                else if (intAscii > 57 && intAscii < 65)
                {
                    return false;
                }
            }
            if (iscomp)
            {
                return CheckCompulsory(Value);
            }
            return true;
        }
        public static bool ValidateAlphabet(string Value, bool iscomp)
        {
            Value = Value.ToUpper().Replace(" ", "").Replace(".", "");
            char[] Val = Value.ToCharArray();
            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii > 90 || intAscii < 65)
                {
                    return false;
                }
            }
            if (iscomp)
            {
                return CheckCompulsory(Value);
            }
            return true;
        }
        public static bool ValidateNormalPassword(string password, bool iscomp)
        {

            string[] st = { };
            for (int c = 0; c < st.Length; c++)
                if (password.IndexOf(st[c]) >= 0)
                {
                    return false;
                }
            if (iscomp)
            {
                if (password.Length == 0)
                {
                    return false;
                }
            }
            return true;
        }
        public static bool ValidateEmail(string Value, bool iscomp)
        {
            string[] st = { };
            if (Value.Length > 0)
            {
                if (Value.IndexOf('@') > 0 && Value.IndexOf('.') > 0)
                {
                    for (int c = 0; c < st.Length; c++)
                        if (Value.IndexOf(st[c]) >= 0)
                        {
                            return false;
                        }
                }
                else
                {
                    return false;
                }
            }
            if (iscomp)
            {
                return CheckCompulsory(Value);
            }
            return true;
        }
        public static bool ValidateNumber(string Value, bool iscomp)
        {
            if (Value.Length > 0 && Value.Substring(0, 1) == "-")
                Value = Value.Substring(1, Value.Length - 1);
            char[] Val = Value.ToCharArray();
            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii < 48 || intAscii > 57)
                {
                    return false;
                }
            }
            if (iscomp)
            {
                return CheckCompulsory(Value);
            }
            return true;
        }
        public static bool CheckCompulsory(string Value)
        {
            if (Value.Length == 0)
            {
                return false;
            }
            return true;
        }
        public static bool ValidateDate(string Value)
        {
            string[] DOBPart = Value.Split('/');
            if (DOBPart.Length != 3)
                return false;
            for (int part = 0; part < 3; part++)
            {
                char[] Val = DOBPart[part].ToCharArray();
                for (int i = 0; i < Val.Length; i++)
                {
                    int intAscii = (int)Val[i];
                    if (intAscii < 48 || intAscii > 57)
                    {
                        return false;
                    }
                }
            }
            // Comment By Anupam
            //if (Convert.ToInt32(DOBPart[0]) > 12 || Convert.ToInt32(DOBPart[0]) < 1)
            //    return false;
            //if (Convert.ToInt32(DOBPart[1]) > 31 || Convert.ToInt32(DOBPart[1]) < 1)
            //    return false;
            if (Convert.ToInt32(DOBPart[0]) > 31 || Convert.ToInt32(DOBPart[0]) < 1)
                return false;
            if (Convert.ToInt32(DOBPart[1]) > 12 || Convert.ToInt32(DOBPart[1]) < 1)
                return false;
            return true;
        }

        public static bool ValidateMobileNumber(string Value)
        {
            if (Value.Length != 10)
                return false;
            char[] Val = Value.ToCharArray();
            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii < 48 || intAscii > 57)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool ValidateMobileNumber(string Value, string CountryCode)
        {
            if (CountryCode == "91" || CountryCode == "+91")
            {
                if (Value.Length != 10)
                    return false;
                char[] Val = Value.ToCharArray();
                for (int i = 0; i < Val.Length; i++)
                {
                    int intAscii = (int)Val[i];
                    if (intAscii < 48 || intAscii > 57)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool ValidatePincode(string Value)
        {
            if (Value.Length != 6)
                return false;
            char[] Val = Value.ToCharArray();
            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii < 48 || intAscii > 57)
                {
                    return false;
                }
            }

            return true;
        }
        public static bool ValidatePincodeOtherThanIndia(string Value)
        {
            if (Value.Length < 4 || Value.Length > 10)
                return false;
            char[] Val = Value.ToCharArray();
            for (int i = 0; i < Val.Length; i++)
            {
                int intAscii = (int)Val[i];
                if (intAscii < 48 || intAscii > 57)
                {
                    return false;
                }
            }

            return true;
        }

        public static string CheckSQL(string valueAsString)
        {
            return (String.IsNullOrEmpty(valueAsString) ? "" : valueAsString.Replace("'", "''").Trim());
        }
    }
}
