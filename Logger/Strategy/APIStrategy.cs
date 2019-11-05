using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Logger.Formatter;
using Logger.Interface;

namespace Logger.Strategy
{
    class APIStrategy : Strategy
    {
        private string _url;
        public  APIStrategy(string postUrl)
        {
            this.setPostUrl(url: postUrl);
        }

        public APIStrategy()
        {

        }

        public void setPostUrl(string url)
        {
            this._url = url;
        }
        public override void close()
        {
            
        }

        public override List<IRecord> getLogs()
        {
            //todo: implement this function!!!
            throw new NotImplementedException();
        }

        public override void deleteLogs()
        {
            throw new WebException();
        }

        private void httpRequest(string jsonContent)
        {
            HttpWebRequest request = (HttpWebRequest) WebRequest.Create(this._url);
            request.Method = "POST";
            UTF8Encoding encoding = new UTF8Encoding();
            Byte[] byteArray = encoding.GetBytes(jsonContent);
            request.ContentLength = byteArray.Length;
            request.ContentType = @"application/json";

            using (Stream dataStream = request.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
            }

            long lenght = 0;
            using HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            /*lenght = response.ContentLength;*/

        }
        public override bool handle(IRecord record)
        {
            JsonFormatter formatter = new JsonFormatter(record);
            string formatted = formatter.format().getFormatted();
            try
            {
                this.httpRequest(formatted);
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
