using System;
using System.IO;
using System.Net;
using System.Text;

namespace Matrix.Net
{
    public class HttpClient
    {
        public event EventHandler Started;

        public event EventHandler Completed;

        public event EventHandler Error;

        private bool _processing;

        public bool Processing
        {
            get { return _processing; }

            private set
            {
                try
                {
                    if (value)
                    {
                        if (Started != null)
                            Started(this, new EventArgs());
                    }

                    if (!value)
                    {
                        if (Completed != null)
                            Completed(this, new EventArgs());
                    }

                    _processing = value;
                }
                catch
                {
                    throw;
                }
            }
        }

        public void Get(string host, string url, string data, Action<string> callback)
        {
            try
            {
                new Action<string, string, string, string, Action<string>>(Execute).BeginInvoke(host, url, "GET", data, callback, null, null);
            }
            catch
            {
                throw;
            }
        }

        public void Post(string host, string url, string data, Action<string> callback)
        {
            try
            {
                new Action<string, string, string, string, Action<string>>(Execute).BeginInvoke(host, url, "POST", data, callback, null, null);
            }
            catch
            {
                throw;
            }
        }

        public void Get(string url, string data, Action<string> callback)
        {
            try
            {
                new Action<string, string, string, string, Action<string>>(Execute).BeginInvoke(null, url, "GET", data, callback, null, null);
            }
            catch
            {
                throw;
            }
        }

        public void Post(string url, string data, Action<string> callback)
        {
            try
            {
                new Action<string, string, string, string, Action<string>>(Execute).BeginInvoke(null, url, "POST", data, callback, null, null);
            }
            catch
            {
                throw;
            }
        }

        private void Execute(string host, string url, string method, string data, Action<string> callback)
        {
            try
            {
                Processing = true;

                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

                if (request != null)
                {
                    request.Method = method;
                    request.UserAgent = "Matrix";

                    if (!string.IsNullOrEmpty(host))
                    {
                        request.Headers["REMOTE_ADDR"] = host;
                        request.Headers["REMOTE_HOST"] = host;
                    }

                    if (method.ToUpper().Equals("POST"))
                    {
                        byte[] postData = Encoding.ASCII.GetBytes(data);

                        request.ContentType = "application/x-www-form-urlencoded";
                        request.ContentLength = postData.Length;

                        using (Stream stream = request.GetRequestStream())
                        {
                            stream.Write(postData, 0, postData.Length);
                            stream.Close();
                        }
                    }

                    HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                    if (response != null)
                    {
                        string result = string.Empty;

                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            result = reader.ReadToEnd();

                        if (callback != null)
                            callback(result);
                    }
                }
            }
            catch (Exception e)
            {
                if (Error != null)
                    Error(e, new EventArgs());
            }
            finally
            {
                Processing = false;
            }
        }
    }
}