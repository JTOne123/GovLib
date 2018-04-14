namespace GovLib.ProPublica.Urls
{
    internal class TestBillUrls : IBillUrls
    {
        public string RecentBills => "https://api.propublica.org/congress/v1/{0}/{1}/bills/{2}.json";
        public string MemberBills => "https://raw.githubusercontent.com/GovLib/ApiResponses/master/propublica/bills/bills-by-member.json";
        public string GetBill => "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        public string BillsBySubject => "https://api.propublica.org/congress/v1/bills/subjects/{0}.json";
        public string UpcomingBills => "https://api.propublica.org/congress/v1/bills/upcoming/{0}.json";
        public string BillByID => "https://api.propublica.org/congress/v1/{0}/bills/{1}.json";
        public string BillAmmendments => "https://api.propublica.org/congress/v1/{0}/bills/{1}/amendments.json";
        public string BillSubjects => "https://api.propublica.org/congress/v1/{0}/bills/{1}/subjects.json";
        public string RelatedBills => "https://api.propublica.org/congress/v1/{0}/bills/{1}/related.json";
        public string Subjects => "https://api.propublica.org/congress/v1/bills/subjects/search.json";
        public string Cosponsors => "https://api.propublica.org/congress/v1/{0}/bills/{1}/cosponsors.json";
    }
}