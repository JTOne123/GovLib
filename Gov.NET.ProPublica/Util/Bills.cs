using System.Net;
using Newtonsoft.Json.Linq;
using Gov.NET.ProPublica.Urls;

namespace Gov.NET.ProPublica.Util
{
    public class Bills
    {
        private Congress _parent;

        internal Bills(Congress parent)
        {
            _parent = parent;
        }

        public JObject GetBillsPassed(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "both", "passed");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetSenateBillsPassed(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "senate", "passed");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHouseBillsPassed(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "house", "passed");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetSenateBillsIntroduced(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "senate", "introduced");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetHouseBillsIntroduced(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "house", "introduced");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetUpdatedSenateBills(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "senate", "updated");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetUpdatedHouseBills(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "house", "updated");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetMajorSenateBills(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "senate", "major");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetMajorHouseBills(int congress)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.RecentBills, congress, "house", "major");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetBillsByMember(string id)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.MemberBills, id, "introduced");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetBillsUpdatedByMember(string id)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.MemberBills, id, "updated");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetBillByID(int congress, string id)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.GetBill, congress, id);
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }

        public JObject GetRelatedBills(int congress, string id)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("X-API-Key", _parent.ApiKey);
                var url = string.Format(BillUrls.GetBill, congress, id, "related");
                var jsonStr = wc.DownloadString(url);
                return JObject.Parse(jsonStr);
            }
        }
    }
}
