using System;
using System.Collections.Generic;
using GovLib.Exceptions;
using GovLib.ProPublica.Builders;
using GovLib.ProPublica.Modules;
using GovLib.ProPublica.Util;
using GovLib.Util;

namespace GovLib.ProPublica
{
    /// <summary>
    /// Retrieve legislative data from ProPublica's US Congress API.
    /// </summary>
    public class Congress
    {
        internal string ApiKey { get; }
        internal Dictionary<string, string> Headers { get; }
        internal IHttpClient Client { get; }
        
        /// <summary>
        /// Get the number of the current congressional session.
        /// </summary>
        /// <returns>Current congress session as a <see cref="int" /></returns>
        public int CurrentCongress
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

        /// <summary>
        /// ProPublica API members module.
        /// </summary>
        /// <returns><see cref="MembersApi" /></returns>
        public MembersApi Members { get; }

        /// <summary>
        /// ProPublica API bills module.
        /// </summary>
        /// <returns><see cref="BillsApi" /></returns>
        public BillsApi Bills { get; }

        /// <summary>
        /// ProPublica API votes module.
        /// </summary>
        /// <returns><see cref="VotesApi" /></returns>
        [Obsolete("Unfinished module not recommended for use.")]
        public VotesApi Votes { get; }

        /// <summary>
        /// Instantiate the library using your API key.
        /// </summary>
        /// <param name="apiKey">ProPublica Congress API key.</param>
        /// <param name="testClient">Set to true for testing.</param>
        public Congress(string apiKey, bool testClient = false)
        {
            if (testClient)
            {
                Members = new MembersApi(this, new TestMemberUrlBuilder());
                Bills = new BillsApi(this, new TestBillUrlBuilder());
                Votes = new VotesApi(this, new TestVoteUrlBuilder());
                Client =  new FileTestClient();
                Headers = new Dictionary<string, string>();
            }
            else
            {
                if (string.IsNullOrEmpty(apiKey))
                    throw new ApiKeyException("ProPublica API key not provided.");

                ApiKey = apiKey;
                Members = new MembersApi(this, new MemberUrlBuilder());
                Bills = new BillsApi(this, new BillUrlBuilder());
                Votes = new VotesApi(this, new VoteUrlBuilder());
                Client = new HttpClient();
                Headers = new Dictionary<string, string>
                {
                    { "X-API-Key", ApiKey }
                };
            }
        }
    }
}
