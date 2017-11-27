namespace Gov.NET.ProPublica.Urls
{
    internal static class MemberUrls
    {
        internal static string AllSenators = "https://api.propublica.org/congress/v1/{0}/senate/members.json";
        internal static string AllRepresentatives = "https://api.propublica.org/congress/v1/{0}/house/members.json";
        internal static string Member = "https://api.propublica.org/congress/v1/members/{0}.json";
        internal static string NewMembers = "https://api.propublica.org/congress/v1/members/new.json";
        internal static string SenatorsByState = "https://api.propublica.org/congress/v1/members/senate/{0}/current.json";
        internal static string RepresentativesByState = "https://api.propublica.org/congress/v1/members/house/{0}/current.json";
        internal static string RepresentativeFromDistrict = "https://api.propublica.org/congress/v1/members/house/{0}/{1}/current.json";
        internal static string SenatorsLeaving = "https://api.propublica.org/congress/v1/{0}/senate/members/leaving.json";
        internal static string RepresentativesLeaving = "https://api.propublica.org/congress/v1/{0}/house/members/leaving.json";
        internal static string VoteRecord = "https://api.propublica.org/congress/v1/members/{0}/votes.json";
        internal static string CompVote = "https://api.propublica.org/congress/v1/members/{0}/votes/{1}/{2}/{3}.json";
        internal static string CompSponsor = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}/{2}/{3}.json";
        internal static string Cosponsor = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}.json";
    }
}
