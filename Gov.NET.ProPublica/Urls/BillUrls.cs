namespace Gov.NET.ProPublica.Urls
{
    public static class BillUrls
    {
        public static string RecentBills = "https://api.propublica.org/congress/v1/{0}/{1}/bills/{2}.json";
        public static string MemberBills = "https://api.propublica.org/congress/v1/members/{0}/bills/{1}.json";
        public static string GetBill = "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        public static string RelatedBills = "https://api.propublica.org/congress/v1/{0}/bills/1}/{2}.json";
    }
}
