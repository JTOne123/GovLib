namespace GovLib.ProPublica.Urls
{
    internal static class TestBillUrls
    {
        internal const string RecentBills = "get-recent-{0}-bills.json";
        internal const string BillsByMember = "get-bills-by-member-{0}.json";
        internal const string GetBill = "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        internal const string BillsBySubject = "get-bills-by-subject-{0}.json";
        internal const string UpcomingBills = "get-upcoming-{0}-bills.json";
        internal const string BillByID = "get-bill-by-id-{0}.json";
        internal const string BillAmmendments = "get-bill-ammendments.json";
        internal const string BillSubjects = "get-bill-subjects-{0}.json";
        internal const string RelatedBills = "get-related-bills-{0}.json";
        internal const string SubjectsByTerm = "get-subjects-by-term-{0}.json";
        internal const string Cosponsors = "get-bill-cosponsors.json";
    }
}
