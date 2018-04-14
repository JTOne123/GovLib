namespace GovLib.ProPublica.Urls
{
    internal static class BillUrls
    {
        internal const string RecentBills = "https://api.propublica.org/congress/v1/{0}/{1}/bills/{2}.json";
        internal const string MemberBills = "https://raw.githubusercontent.com/GovLib/ApiResponses/master/propublica/bills/bills-by-member.json";
        internal const string GetBill = "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        internal const string BillsBySubject = "https://api.propublica.org/congress/v1/bills/subjects/{0}.json";
        internal const string UpcomingBills = "https://api.propublica.org/congress/v1/bills/upcoming/{0}.json";
        internal const string BillByID = "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        internal const string BillAmmendments = "https://api.propublica.org/congress/v1/{0}/bills/{1}/amendments.json";
        internal const string BillSubjects = "https://api.propublica.org/congress/v1/{0}/bills/{1}/subjects.json";
        internal const string RelatedBills = "https://api.propublica.org/congress/v1/{0}/bills/{1}/related.json";
        internal const string Subjects = "https://api.propublica.org/congress/v1/bills/subjects/search.json";
        internal const string Cosponsors = "https://api.propublica.org/congress/v1/{0}/bills/{1}/cosponsors.json";
    }
}
