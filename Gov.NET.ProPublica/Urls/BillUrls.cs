namespace Gov.NET.ProPublica.Urls
{
    internal static class BillUrls
    {
        internal static string RecentBills = "https://api.propublica.org/congress/v1/{0}/{1}/bills/{2}.json";
        internal static string MemberBills = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}.json";
        internal static string GetBill = "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        internal static string RelatedBills = "https://api.propublica.org/congress/v1/{0}/bills/1}/{2}.json";
    }
}
