namespace GovLib.ProPublica.Urls
{
    internal class MemberUrls
    {
        internal const string AllSenators = "https://api.propublica.org/congress/v1/{0}/senate/members.json";
        internal const string AllRepresentatives = "https://api.propublica.org/congress/v1/{0}/house/members.json";
        internal const string Member = "https://api.propublica.org/congress/v1/members/{0}.json";
        internal const string NewMembers = "https://api.propublica.org/congress/v1/members/new.json";
        internal const string SenatorsByState = "https://api.propublica.org/congress/v1/members/senate/{0}/current.json";
        internal const string RepresentativesByState = "https://api.propublica.org/congress/v1/members/house/{0}/current.json";
        internal const string RepresentativeFromDistrict = "https://api.propublica.org/congress/v1/members/house/{0}/{1}/current.json";
        internal const string SenatorsLeaving = "https://api.propublica.org/congress/v1/{0}/senate/members/leaving.json";
        internal const string RepresentativesLeaving = "https://api.propublica.org/congress/v1/{0}/house/members/leaving.json";
        internal const string VoteRecord = "https://api.propublica.org/congress/v1/members/{0}/votes.json";
        internal const string CompVote = "https://api.propublica.org/congress/v1/members/{0}/votes/{1}/{2}/{3}.json";
        internal const string CompSponsor = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}/{2}/{3}.json";
        internal const string Cosponsor = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}.json";
    }
}
