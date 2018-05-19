using GovLib.ProPublica.Urls;

namespace GovLib.ProPublica.Builders
{
    internal class VoteUrlBuilder : IVoteUrlBuilder
    {
        public string RecentVotes(string chamber) =>
            string.Format(VoteUrls.RecentVotes, chamber);

        public string RollCallVote(string congressNum, string chamber, string sessionNum, string rollCallNum) =>
            string.Format(VoteUrls.RollCallVote, congressNum, chamber, sessionNum, rollCallNum);

        public string VotesByType(string congressNum, string chamber, string voteType) =>
            string.Format(VoteUrls.VotesByType, chamber, voteType);

        public string VotesByDate(string chamber, string year, string month) =>
            string.Format(VoteUrls.VotesByDate, year, month);

        public string VotesByDateRange(string chamber, string startDate, string endDate) =>
            string.Format(VoteUrls.VotesByDate, startDate, endDate);

        public string SenateNominationVotes(string congressNum) =>
            string.Format(VoteUrls.VotesByType, congressNum);

    }
}