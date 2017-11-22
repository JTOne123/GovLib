namespace Gov.NET.ProPublica.Urls
{
    public static class VoteUrls
    {
        public static string RollCall = "https://api.propublica.org/congress/v1/{0}/{1}/sessions/{2}/votes/{3}.json";
        public static string VoteByType = "https://api.propublica.org/congress/v1/{0}/{1}/votes/{2}.json";
        public static string VoteByDate = "https://api.propublica.org/congress/v1/{0}/votes/{1}/{2}.json";
        public static string Nominations = "https://api.propublica.org/congress/v1/{0}/nominations.json";
    }
}
