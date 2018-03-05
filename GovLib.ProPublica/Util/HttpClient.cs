using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using GovLib.Util;
using System;

namespace GovLib.ProPublica.Util
{
    internal class HttpClient: WebClient, IHttpClient
    {
        public string Get(string url, Dictionary<string, string> headers = null)
        {
            using (var wc = new WebClient())
            {
                AddHeaders(wc, headers);
                var jsonStr = wc.DownloadString(url);
                try
                {
                    return wc.DownloadString(url);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"HttpClient error: {e.Message}");
                    return null;
                }
            }
        }

        private static void AddHeaders(WebClient webClient, Dictionary<string, string> headers)
        {
            if (headers == null || headers.Keys.Count == 0)
                return;

            foreach (var key in headers.Keys)
            {
                webClient.Headers.Add(key, headers[key]);
            }
        }
    }
}
