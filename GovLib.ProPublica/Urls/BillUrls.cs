namespace GovLib.ProPublica.Urls
{
    internal class BillUrls
    {
        internal const string RecentBills = "https://api.propublica.org/congress/v1/{0}/{1}/bills/{2}.json";
        internal const string MemberBills = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}.json";
        internal const string GetBill = "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        internal const string RelatedBills = "https://api.propublica.org/congress/v1/{0}/bills/1}/{2}.json";
        internal const string BillsBySubject = "https://api.propublica.org/congress/v1/bills/subjects/{0}.json";
        internal const string UpcomingBills = "https://api.propublica.org/congress/v1/bills/upcoming/{0}.json";
        internal const string BillByID = "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        internal const string BillAmmendments = "https://api.propublica.org/congress/v1/{0}/bills/{1}/amendments.json";
        internal const string BillSubjects = "https://api.propublica.org/congress/v1/{0}/bills/{1}/subjects.json";
    }
}
