using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Gov.NET
{
    internal class HttpClient: WebClient
    {
        internal T Get<T>(string url, Dictionary<string, string> headers = null) where T: class
        {
            using (var wc = new WebClient())
            {
                AddHeaders(wc, headers);
                var jsonStr = wc.DownloadString(url);
                return JsonConvert.DeserializeObject<T>(jsonStr);
            }
        }

        internal static void AddHeaders(WebClient webClient, Dictionary<string, string> headers)
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
