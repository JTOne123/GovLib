using System;
using System.Collections.Generic;
using GovLib.Core.Util;
using GovLib.Exceptions;
using GovLib.ProPublica.Modules;
using GovLib.ProPublica.Util;

namespace GovLib.ProPublica
{
    /// <summary>
    /// Retrieve legislative data from ProPublica's US Congress API.
    /// </summary>
    public class Congress
    {
        internal string ApiKey { get; }
        internal Dictionary<string, string> Headers { get; }
        internal Dictionary<int, MemberCache> Cache { get; }
        internal IHttpClient HttpClient { get; }
        
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
        [Obsolete("Unfished module, not recommended for use")]
        public VotesApi Votes { get; }

        /// <summary>
        /// Instantiate the library using your API key.
        /// </summary>
        /// <param name="apiKey">ProPublica Congress API key.</param>
        public Congress(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ApiKeyException("ProPublica API key not provided.");

            ApiKey = apiKey;
            Members = new MembersApi(this);
            Votes = new VotesApi(this);
            Bills = new BillsApi(this);
            Cache = new Dictionary<int, MemberCache>();
            HttpClient = new HttpClient();
            Headers = new Dictionary<string, string>
            {
                { "X-API-Key", ApiKey }
            };
            Members.PopulateCache(CurrentCongress);
        }

        /// <summary>
        /// Instantiate the library with a custom HttpClient (for debugging).
        /// </summary>
        /// <param name="apiKey">ProPublica Congress API key.</param>
        /// <param name="httpClient"><see cref="IHttpClient" />implementation.</param>
        public Congress(string apiKey, IHttpClient httpClient)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new ApiKeyException("ProPublica API key not provided.");

            ApiKey = apiKey;
            Members = new MembersApi(this);
            Votes = new VotesApi(this);
            Bills = new BillsApi(this);
            Cache = new Dictionary<int, MemberCache>();
            HttpClient = httpClient;
            Headers = new Dictionary<string, string>
            {
                { "X-API-Key", ApiKey }
            };
            Members.PopulateCache(CurrentCongress);
        }
    }
}
