namespace GovLib.ProPublica.Urls
{
    internal class VoteUrls
    {
        internal const string RecentVotes = "https://api.propublica.org/congress/v1/{0}/votes/recent.json";
        internal const string RollCallVote = "https://api.propublica.org/congress/v1/{0}/{1}/sessions/{2}/votes/{3}.json";
        internal const string VotesByType = "https://api.propublica.org/congress/v1/{0}/{1}/votes/{2}.json";
        internal const string VotesByDate = "https://api.propublica.org/congress/v1/{0}/votes/{1}/{2}.json";
        internal const string NominationsVotes = "https://api.propublica.org/congress/v1/{0}/nominations.json";
    }
}
