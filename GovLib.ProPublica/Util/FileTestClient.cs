using System.Collections.Generic;
using System.IO;
using GovLib.Util;

namespace GovLib.ProPublica.Util
{
    internal class FileTestClient : IHttpClient
    {
        public string Get(string url, Dictionary<string, string> headers = null)
        {
            return File.ReadAllText(url);
        }
    }
}