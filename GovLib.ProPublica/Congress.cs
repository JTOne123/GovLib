using System.Collections.Generic;
using GovLib.ProPublica.Modules;

namespace GovLib.ProPublica
{
    /// <summary>Retrieve legislative data from ProPublica's US Congress API.</summary>
    public class Congress
    {
        internal string ApiKey { get; }
        internal Dictionary<string, string> Headers { get; }

        /// <summary>Get information about members of congress.</summary>
        public Members Members { get; }

        /// <summary>Get information about current or previous bills introduced.</summary>
        public Bills Bills { get; }

        /// <summary>Get congressional vote statistics.</summary>
        public Votes Votes { get; }

        /// <summary>Instantiate the library using your ProPublica Congress API key.</summary>
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
