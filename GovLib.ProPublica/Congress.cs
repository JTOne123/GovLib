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
        public MembersApi MembersApi { get; }

        /// <summary>Get information about current or previous bills introduced.</summary>
        public BillsApi BillsApi { get; }

        /// <summary>Get congressional vote statistics.</summary>
        public VotesApi VotesApi { get; }


        /// <summary>Instantiate the library using your ProPublica Congress API key.</summary>
        public Congress(string apiKey)
        {
            ApiKey = apiKey;
            MembersApi = new MembersApi(this);
            VotesApi = new VotesApi(this);
            BillsApi = new BillsApi(this);
            Cache = new Dictionary<int, MemberCache>();
            Headers = new Dictionary<string, string>
            {
                { "X-API-Key", ApiKey }
            };
        }
    }
}
