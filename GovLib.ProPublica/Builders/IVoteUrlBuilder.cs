namespace GovLib.ProPublica.Builders
{
    internal interface IVoteUrlBuilder
    {
        string RecentVotes(string chamber);
        string RollCallVote(string congressNum, string chamber, string sessionNum, string rollCallNum);
        string VotesByType(string congressNum, string chamber, string voteType);
        string VotesByDate(string chamber, string year, string month);
        string VotesByDateRange(string chamber, string startDate, string endDate);
        string SenateNominationVotes(string congressNum);
    }
}