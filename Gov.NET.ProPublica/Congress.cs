using System.Collections.Generic;
using Gov.NET.ProPublica.Util;

namespace Gov.NET.ProPublica
{
    public class Congress
    {
        public string ApiKey { get; }
        public Members Members { get; private set; }
        public Votes Votes { get; private set; }
        public Bills Bills { get; private set; }
        public Dictionary<string, string> Headers { get; private set; }

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
