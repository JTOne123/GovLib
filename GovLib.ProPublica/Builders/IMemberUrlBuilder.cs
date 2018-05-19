namespace GovLib.ProPublica.Builders
{
    internal interface IMemberUrlBuilder
    {
        string AllSenators(string congressNum);
        string AllRepresentatives(string congressNum);
        string MemberByID(string id);
        string NewMembers();
        string SenatorsByState(string state);
        string RepresentativesByState(string state);
        string RepresentativeFromDistrict(string state, string district);
        string SenatorsLeaving(string congressNum);
        string RepresentativesLeaving(string congressNum);
    }
}