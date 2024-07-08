using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Web.UI;
using RestSharp;
using System.Web;
using System.Net;
using System.IO;
using System.Data;
using Newtonsoft.Json;
using System.Xml;

namespace AllenLibrary.Utility
{
    public class HttpHelper
    {
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

        #region RestClient
        public static String HttpRestRequest(string url, Dictionary<string, string> postParameters)
        {
            string data = "";
            try
            {
                var client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AlwaysMultipartFormData = true;

                foreach (var pair in postParameters)
                {
                    request.AddParameter(pair.Key, pair.Value);
                }

                IRestResponse response = client.Execute(request);
                data = response.Content;
            }
            catch (Exception ex)
            {
                data = ex.Message;
            }

            return data;
        }
        #endregion

        #region application/x-www-form-urlencoded
        public static String HttpPostUrlEncodedRequest(string url, Dictionary<string, string> postParameters)
        {
            try
            {
                string postData = "";

                foreach (string key in postParameters.Keys)
                {
                    postData += HttpUtility.UrlEncode(key) + "="
                          + HttpUtility.UrlEncode(postParameters[key]) + "&";
                }

                HttpWebRequest myHttpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                myHttpWebRequest.Method = "POST";

                byte[] data = Encoding.ASCII.GetBytes(postData);

                myHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
                myHttpWebRequest.ContentLength = data.Length;

                Stream requestStream = myHttpWebRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();

                HttpWebResponse myHttpWebResponse = (HttpWebResponse)myHttpWebRequest.GetResponse();

                Stream responseStream = myHttpWebResponse.GetResponseStream();

                StreamReader myStreamReader = new StreamReader(responseStream, Encoding.Default);

                string pageContent = myStreamReader.ReadToEnd();

                myStreamReader.Close();
                responseStream.Close();

                myHttpWebResponse.Close();

                return pageContent;
            }
            catch (Exception)
            {

            }

            return "";
        }
        #endregion

        #region Get Request
        public String HttpGetRequest(string url)
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
            //System.Diagnostics.Debug.Write(sb.ToString());

            //DataSet ds = JsonConvert.DeserializeObject<DataSet>(sb.ToString());
            if (sb != null)
                return sb.ToString();
            else
                return "";
        }

        public DataSet APIResponseCode(string filePath, int code, string message)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add("status", typeof(int));
            dt.Columns.Add("message", typeof(string));

            if (String.IsNullOrEmpty(filePath)
                && !String.IsNullOrEmpty(message))
            {
                dt.Rows.Add(code, message);
            }
            else if (File.Exists(filePath))
            {
                XmlDocument document = new XmlDocument();
                document.Load(filePath);

                if (document != null)
                {
                    var response = document.SelectSingleNode("response/code-" + code.ToString());
                    if (response != null)
                        dt.Rows.Add(code, response.InnerText.Trim());
                }
            }

            if (dt != null && dt.Rows.Count > 0)
            {
                ds.Tables.Add(dt);
                return ds;
            }

            return null;
        }
        #endregion
    }
}
