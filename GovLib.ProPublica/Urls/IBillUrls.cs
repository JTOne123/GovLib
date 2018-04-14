namespace GovLib.ProPublica.Urls
{
    internal interface IBillUrls
    {
        string RecentBills { get; }
        string MemberBills { get; }
        string GetBill { get; }
        string BillsBySubject { get; }
        string UpcomingBills { get; }
        string BillByID { get; }
        string BillAmmendments { get; }
        string BillSubjects { get; }
        string RelatedBills { get; }
        string Subjects { get; }
        string Cosponsors { get; }
    }
}
