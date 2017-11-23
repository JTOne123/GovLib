using System.Collections.Generic;

namespace Gov.NET.ProPublica.Util
{
    internal static class HeaderProvider
    {
        internal static Dictionary<string, string> GenerateHeaderDictionary(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                return null;

            return new Dictionary<string, string>
            {
                {"X-API-Key", apiKey }
            };
        }
    }
}
