using System.IO;
using System.Reflection;
using GovLib.ProPublica.Urls;

namespace GovLib.ProPublica.Builders
{
    internal class TestMemberUrlBuilder : IMemberUrlBuilder
    {
        private readonly string _memberPath;

        internal TestMemberUrlBuilder()
        {
            var slnPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _memberPath = Path.Combine(slnPath, "GovLib.Examples/Members");
        }

        public string AllSenators(string congressNum) =>
            Path.Combine(_memberPath, TestMemberUrls.AllSenators);
        
        public string AllRepresentatives(string congressNum) =>
            Path.Combine(_memberPath, TestMemberUrls.AllRepresentatives);
        
        public string MemberByID(string id) =>
            Path.Combine(_memberPath, TestMemberUrls.MemberById);
        
        public string NewMembers() =>
            Path.Combine(_memberPath, TestMemberUrls.NewMembers);
        
        public string SenatorsByState(string state) =>
            Path.Combine(_memberPath, TestMemberUrls.SenatorsByState);
        
        public string RepresentativesByState(string state) =>
            Path.Combine(_memberPath, TestMemberUrls.RepresentativesByState);
        
        public string RepresentativeFromDistrict(string state, string district) =>
            Path.Combine(_memberPath, TestMemberUrls.RepresentativeFromDistrict);

        public string SenatorsLeaving(string congressNum) =>
            Path.Combine(_memberPath, TestMemberUrls.SenatorsLeaving);

        public string RepresentativesLeaving(string congressNum) =>
            Path.Combine(_memberPath, TestMemberUrls.RepresentativesLeaving);
    }
}