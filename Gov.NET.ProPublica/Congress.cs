using System.Collections.Generic;
using Gov.NET.ProPublica.Util;

namespace Gov.NET.ProPublica
{
    public class Congress
    {
        internal string ApiKey { get; }
        public Members Members { get; }
        public Votes Votes { get; }
        public Bills Bills { get; }
        internal Dictionary<string, string> Headers { get; }

        public Congress(string apiKey)
        {
            ApiKey = apiKey;
            Members = new Members(this);
            Votes = new Votes(this);
            Bills = new Bills(this);
            Headers = new Dictionary<string, string>
            {
                { "X-API-Key", ApiKey }
            };
        }
    }
}
