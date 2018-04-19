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
    public class VotesApi
    {
        private Congress _congress { get; }
        private IVoteUrlBuilder _voteUrlBuilder { get; }

        internal VotesApi(Congress congress, IVoteUrlBuilder voteUrlBuilder)
        {
            _congress = congress;
            _voteUrlBuilder = voteUrlBuilder;
        }
        
        public IEnumerable<Vote> GetRecentVotes(Chamber chamber)
        {
            var url = _voteUrlBuilder.RecentVotes(EnumConvert.ChamberEnumToString(chamber));
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
        
        public IEnumerable<Vote> GetRollCallVote(Chamber chamber, int congressNum, int sessionNum, int rollCallNum)
        {
            var ch = EnumConvert.ChamberEnumToString(chamber);
            var url = _voteUrlBuilder.RollCallVote(ch, congressNum.ToString(), sessionNum.ToString(), rollCallNum.ToString());
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
        
        public IEnumerable<Vote> GetVotesByType(Chamber chamber, int congressNum, string voteType)
        {
            var ch = EnumConvert.ChamberEnumToString(chamber);
            var url = _voteUrlBuilder.VotesByType(ch, congressNum.ToString(), voteType);
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
        
        public IEnumerable<Vote> GetVotesByDate(Chamber chamber, int year, int month)
        {
            var ch = EnumConvert.ChamberEnumToString(chamber);
            var url = _voteUrlBuilder.VotesByDate(ch, year.ToString(), month.ToString());
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
        
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

        public IEnumerable<Vote> GetSenateNominationVotes(int congress)
        {
            var url = _voteUrlBuilder.SenateNominationVotes(congress.ToString());
            var result = _congress.Client.Get(url);
            var json = JsonConvert.DeserializeObject<ResultWrapper<VotesWrapper<ApiVote>>>(result);
            return json?.Result?.Votes?.Select(v => ApiVote.Convert(v));
        }
    }
}
