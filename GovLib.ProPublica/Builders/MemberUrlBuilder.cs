using GovLib.ProPublica.Urls;

namespace GovLib.ProPublica.Builders
{
    internal class MemberUrlBuilder : IMemberUrlBuilder
    {
        public string AllSenators(string congressNum) =>
            string.Format(MemberUrls.AllSenators, congressNum);
        
        public string AllRepresentatives(string congressNum) =>
            string.Format(MemberUrls.AllRepresentatives, congressNum);
        
        public string MemberByID(string id) =>
            string.Format(MemberUrls.Member, id);
        
        public string NewMembers() =>
            MemberUrls.NewMembers;
        
        public string SenatorsByState(string state) =>
            string.Format(MemberUrls.SenatorsByState, state);
        
        public string RepresentativesByState(string state) =>
            string.Format(MemberUrls.RepresentativesByState, state);
        
        public string RepresentativeFromDistrict(string state, string district) =>
            string.Format(MemberUrls.RepresentativeFromDistrict, state, district);

        public string SenatorsLeaving(string congressNum) =>
            string.Format(MemberUrls.SenatorsLeaving, congressNum);

        public string RepresentativesLeaving(string congressNum) =>
            string.Format(MemberUrls.RepresentativesLeaving, congressNum);
    }
}