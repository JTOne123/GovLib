using System;
using System.Collections.Generic;
using GovLib.ProPublica.Modules;
using GovLib.ProPublica.Util;

namespace GovLib.ProPublica
{
    /// <summary>Retrieve legislative data from ProPublica's US Congress API.</summary>
    public class Congress
    {
        internal string ApiKey { get; }
        internal Dictionary<string, string> Headers { get; }
        internal Dictionary<int, MemberCache> Cache { get; }
        internal int CurrentCongress
        {
            get
            {
                var now = DateTime.UtcNow;
                var firstCongress = new DateTime(1789, 1, 3);
                var ticks = now.Subtract(firstCongress).Ticks;
                var yearsPassed = new DateTime(ticks).Year + 1;
                return yearsPassed / 2;
            }
        }

        /// <summary>Get information about members of congress.</summary>
        public MembersApi Members { get; }

        /// <summary>Get information about current or previous bills introduced.</summary>
        [Obsolete("Unfished module not recommended for use")]
        public BillsApi Bills { get; }

        /// <summary>Get congressional vote statistics.</summary>
        [Obsolete("Unfished module not recommended for use")]
        public VotesApi Votes { get; }


        /// <summary>Instantiate the library using your ProPublica Congress API key.</summary>
        public Congress(string apiKey)
        {
            ApiKey = apiKey;
            Members = new MembersApi(this);
            Votes = new VotesApi(this);
            Bills = new BillsApi(this);
            Cache = new Dictionary<int, MemberCache>();
            Headers = new Dictionary<string, string>
            {
                { "X-API-Key", ApiKey }
            };
        }
    }
}
