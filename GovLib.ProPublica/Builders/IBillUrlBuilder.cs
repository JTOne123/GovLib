namespace GovLib.ProPublica.Builders
{
    internal interface IBillUrlBuilder
    {
        string RecentBills(Chamber chamber, BillStatus status, int congressNum);
        string BillsByMember(string congressID);
        string BillsBySubject(string subject);
        string UpcomingBills(Chamber chamber);
        string BillByID(int congressNum, string id);
        string BillAmmendments(int congressNum, string id);
        string BillSubjects(int congressNum, string id);
        string RelatedBills(int congressNum, string id);
        string SubjectsByTerm(string term);
        string Cosponsors(int congressNum, string id);
    }
}