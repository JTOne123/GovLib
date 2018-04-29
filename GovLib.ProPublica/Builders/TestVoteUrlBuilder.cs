using System.IO;
using System.Reflection;
using GovLib.ProPublica.Urls;
using static GovLib.Util.EnumConvert;

namespace GovLib.ProPublica.Builders
{
    internal class TestVoteUrlBuilder : IVoteUrlBuilder
    {
        private readonly string _votePath;

        internal TestVoteUrlBuilder()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _votePath = Path.Combine(assemblyPath, "ProPublica", "Votes");
        }
        
        public string RecentVotes(string chamber) =>
            Path.Combine(_votePath, string.Format(TestVoteUrls.RecentVotes, chamber));

        public string RollCallVote(string chamber, string congressNum, string sessionNum, string rollCallNum) =>
            Path.Combine(_votePath, string.Format(TestVoteUrls.RollCallVote, chamber));

        public string VotesByType(string congressNum, string chamber, string voteType) =>
            Path.Combine(_votePath, string.Format(TestVoteUrls.VotesByType, chamber));

        public string VotesByDate(string chamber, string year, string month) =>
            Path.Combine(_votePath, string.Format(TestVoteUrls.VotesByDate, chamber));

        public string VotesByDateRange(string chamber, string startDate, string endDate) =>
            Path.Combine(_votePath, string.Format(TestVoteUrls.VotesByDateRange, chamber));

        public string SenateNominationVotes(string congressNum) =>
            Path.Combine(_votePath, TestVoteUrls.NominationsVotes);
        
    }
}