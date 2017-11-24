namespace Gov.NET.ProPublica.Urls
{
    public static class MemberUrls
    {
        public static string AllMembers = "https://api.propublica.org/congress/v1/{0}/{1}/members.json";
        public static string Member = "https://api.propublica.org/congress/v1/members/{0}.json";
        public static string NewMembers = "https://api.propublica.org/congress/v1/members/new.json";
        public static string SenatorsByState = "https://api.propublica.org/congress/v1/members/senate/{0}/current.json";
        public static string RepresentativesByState = "https://api.propublica.org/congress/v1/members/house/{0}/current.json";
        public static string RepresentativeFromDistrict = "https://api.propublica.org/congress/v1/members/house/{0}/{1}/current.json";
        public static string SenatorsLeaving = "https://api.propublica.org/congress/v1/{0}/senate/members/leaving.json";
        public static string RepresentativesLeaving = "https://api.propublica.org/congress/v1/{0}/house/members/leaving.json";
        public static string VoteRecord = "https://api.propublica.org/congress/v1/members/{0}/votes.json";
        public static string CompVote = "https://api.propublica.org/congress/v1/members/{0}/votes/{1}/{2}/{3}.json";
        public static string CompSponsor = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}/{2}/{3}.json";
        public static string Cosponsor = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}.json";
    }
}
