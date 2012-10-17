﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace Forex
{
    class Utils
    {
        public static string GetHtml(string url)
        {
            string html = null;
            WebClient wc = new WebClient();
            try { html = wc.DownloadString(url); }
            catch { }
            wc.Dispose();
            return html;
        }

        public static string GetHtml(string url, Encoding encoding)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Timeout = 100 * 1000;
            request.Method = "GET";
            request.MaximumAutomaticRedirections = 1000;
            request.ContentType = "text/html";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,* / *;q=0.8";
            request.AllowAutoRedirect = true;
            request.KeepAlive = true;
            request.ProtocolVersion = HttpVersion.Version10;
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:15.0) Gecko/20100101 Firefox/15.0.1";
            request.UseDefaultCredentials = true;
            string html = null;

            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader srd = new StreamReader(response.GetResponseStream(), encoding))
                    {
                        html = srd.ReadToEnd();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Data);
            }
            finally
            {
                request.Abort();
            }
            return html;
        }
    }
}
