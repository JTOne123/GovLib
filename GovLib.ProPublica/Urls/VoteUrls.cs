namespace GovLib.ProPublica.Urls
{
    internal class VoteUrls
    {
        internal const string RollCall = "https://api.propublica.org/congress/v1/{0}/{1}/sessions/{2}/votes/{3}.json";
        internal const string VoteByType = "https://api.propublica.org/congress/v1/{0}/{1}/votes/{2}.json";
        internal const string VoteByDate = "https://api.propublica.org/congress/v1/{0}/votes/{1}/{2}.json";
        internal const string Nominations = "https://api.propublica.org/congress/v1/{0}/nominations.json";
    }
}
