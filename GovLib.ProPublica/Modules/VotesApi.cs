using System.Net;
using Newtonsoft.Json.Linq;
using GovLib.ProPublica.Urls;
using GovLib.ProPublica.Builders;
using System.Collections.Generic;
using GovLib.Util;
using Newtonsoft.Json;
using GovLib.ProPublica.Util.ApiModels.Wrappers;
using GovLib.ProPublica.Util.ApiModels.VoteModels;
using System.Linq;
using System;

namespace GovLib.ProPublica.Modules
{
    /// <summary>
    /// Get information about congressional votes
    /// </summary>
    public class VotesApi
    {
        private Congress _congress { get; }
        private IVoteUrlBuilder _voteUrlBuilder { get; }

        internal VotesApi(Congress congress, IVoteUrlBuilder voteUrlBuilder)
        {
            _congress = congress;
            _voteUrlBuilder = voteUrlBuilder;
        }
        
        /// <summary>
        /// Get the 20 most recent votes of the given chamber.
        /// </summary>
        /// <param name="chamber"><see cref="Chamber"/></param>
        /// <returns>An enumerable collection of recent vote results.</returns>
        public IEnumerable<Vote> GetRecentVotes(Chamber chamber)
        {
            var url = _voteUrlBuilder.RecentVotes(EnumConvert.ChamberEnumToString(chamber));
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
        
        /// <summary>
        /// Get a specific roll call vote.
        /// </summary>
        /// <param name="chamber"><see cref="Chamber"/></param>
        /// <param name="congressNum">Congress number</param>
        /// <param name="sessionNum">Session number (1 for odd year, 2 for even year)</param>
        /// <param name="rollCallNum">Roll call number</param>
        /// <returns>The specified roll call vote result.</returns>
        public VoteRollCall GetRollCallVote(Chamber chamber, int congressNum, int sessionNum, int rollCallNum)
        {
            var ch = EnumConvert.ChamberEnumToString(chamber);
            var url = _voteUrlBuilder.RollCallVote(ch, congressNum.ToString(), sessionNum.ToString(), rollCallNum.ToString());
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesSingularWrapper<VoteRollCallWrapper<ApiRollCallVote>>>>(result);
            return ApiRollCallVote.Convert(json?.Result?.Votes?.Vote);
        }
        
        /// <summary>
        /// Get vote information from the given category.
        /// </summary>
        /// <param name="chamber"><see cref="Chamber"/></param>
        /// <param name="congressNum">Congress number</param>
        /// <param name="voteType"></param>
        /// <returns>An enumerable collection of related votes.</returns>
        public IEnumerable<Vote> GetVotesByType(Chamber chamber, int congressNum, string voteType)
        {
            var ch = EnumConvert.ChamberEnumToString(chamber);
            var url = _voteUrlBuilder.VotesByType(ch, congressNum.ToString(), voteType);
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
        
        /// <summary>
        /// Get votes performed in the given month.
        /// </summary>
        /// <param name="chamber"><see cref="Chamber"/></param>
        /// <param name="year">Year of vote</param>
        /// <param name="month">Month of vote</param>
        /// <returns>An enumerable collection of votes during the given time.</returns>
        public IEnumerable<Vote> GetVotesByDate(Chamber chamber, int year, int month)
        {
            var ch = EnumConvert.ChamberEnumToString(chamber);
            var url = _voteUrlBuilder.VotesByDate(ch, year.ToString(), month.ToString());
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
        
        /// <summary>
        /// Get votes performed during the given time range.
        /// </summary>
        /// <param name="chamber"><see cref="Chamber"/></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>An enumerable collection of votes during the given time.</returns>
        public IEnumerable<Vote> GetVotesByDateRange(Chamber chamber, DateTime startDate, DateTime endDate)
        {
            var ch = EnumConvert.ChamberEnumToString(chamber);
            var start = $"{startDate.Year}-{startDate.Month}-{startDate.Day}";
            var end = $"{endDate.Year}-{endDate.Month}-{endDate.Day}";
            var url = _voteUrlBuilder.VotesByDate(ch, start, end);
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }

        /// <summary>
        /// Get nomination votes performed during the given congress session.
        /// </summary>
        /// <param name="congress">Congress number</param>
        /// <returns>An enumerable collection of senate nomination votes.</returns>
        public IEnumerable<Vote> GetSenateNominationVotes(int congress)
        {
            var url = _voteUrlBuilder.SenateNominationVotes(congress.ToString());
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
    }
}
