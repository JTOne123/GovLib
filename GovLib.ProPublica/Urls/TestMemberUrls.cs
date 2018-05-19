using System.IO;

namespace GovLib.ProPublica.Urls
{
    internal static class TestMemberUrls
    {
        internal const string AllSenators = "get-all-senators.json";
        internal const string AllRepresentatives = "get-all-representatives.json";
        internal const string MemberById = "get-member-by-id-{0}.json";
        internal const string NewMembers = "get-new-members.json";
        internal const string SenatorsByState = "get-senators-by-state.json";
        internal const string RepresentativesByState = "get-representatives-by-state.json";
        internal const string RepresentativeFromDistrict = "get-representative-from-district.json";
        internal const string SenatorsLeaving = "get-senators-leaving-office.json";
        internal const string RepresentativesLeaving = "get-representatives-leaving-office.json";
    }
}