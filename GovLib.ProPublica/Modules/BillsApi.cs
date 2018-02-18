using System.Net;
using Newtonsoft.Json.Linq;
using GovLib.ProPublica.Urls;
using GovLib.Contracts;
using GovLib.ProPublica.Util;
using GovLib.Util;
using GovLib.ProPublica.Util.ApiModels.BillModels;
using System.Linq;

namespace GovLib.ProPublica.Modules
{
    /// <summary> Get information about bills introduced to congress.</summary>
    public class BillsApi
    {
        private Congress _parent { get; }

        internal BillsApi(Congress parent)
        {
            _parent = parent;
        }

        /// <summary> Get recent bills by status.</summary>
        public Bill[] GetRecentBills(Chamber chamber, BillStatus status)
        {
            return GetRecentBills(chamber, _parent.CurrentCongress, status);
        }

        /// <summary> Get historical bills by status.</summary>
        public Bill[] GetRecentBills(Chamber chamber, int congress, BillStatus status)
        {
            using (var client = new HttpClient())
            {
                var chamberString = EnumConvert.ChamberEnumToString(chamber);
                var statusString = EnumConvert.BillStatusEnumToString(status);
                var url = string.Format(BillUrls.RecentBills, congress, chamberString, statusString);
                var result = client.Get<ResultWrapper<BillsWrapper<ApiBill>>>(url, _parent.Headers);
                return result?.Results?[0].Bills.Select(b => ApiBill.Convert(b, _parent.Cache[congress])).ToArray();
            }
        }

        /// <summary> Get recent bills by member.</summary>
        public Bill[] GetRecentBillsByMember(ICongressMember congressMember)
        {
            return GetRecentBillsByMember(congressMember.CongressID);
        }

        /// <summary> Get recent bills by member id.</summary>
        public Bill[] GetRecentBillsByMember(string id)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(BillUrls.MemberBills, id, "introduced");
                var result = client.Get<ResultWrapper<BillsWrapper<ApiBill>>>(url, _parent.Headers);
                return result?.Results?[0].Bills.Select(b => ApiBill.Convert(b, _parent.Cache[_parent.CurrentCongress])).ToArray();
            }
        }

        /// <summary>
        /// Get the 20 most recently updated bills for a specific legislative subject.
        /// </summary>
        /// <param name="subject">Terms to search for.</param>
        /// <returns><see cref="Bill"/>array.</returns>
        public Bill[] GetRecentBillsBySubject(string subject)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(BillUrls.BillsBySubject, subject);
                var result = client.Get<ResultWrapper<BillsWrapper<ApiBill>>>(url, _parent.Headers);
                return result?.Results?[0].Bills.Select(b => ApiBill.Convert(b, _parent.Cache[_parent.CurrentCongress])).ToArray();
            }
        }

        /// <summary>
        /// Get bills that may be considered in the near future.
        /// </summary>
        /// <param name="chamber">Chamber of congress.</param>
        /// <returns><see cref="BillSummary"/>array.</returns>
        public BillSummary[] GetUpcomingBills(Chamber chamber)
        {
            using (var client = new HttpClient())
            {
                var chamberString = EnumConvert.ChamberEnumToString(chamber);
                var url = string.Format(BillUrls.UpcomingBills, chamberString);
                var result = client.Get<ResultWrapper<BillsWrapper<ApiUpcomingBills>>>(url, _parent.Headers);
                return result?.Results?[0].Bills.Select(b => ApiUpcomingBills.Convert(b)).ToArray();
            }
        }

        /// <summary>
        /// Get information about a specific bill.
        /// </summary>
        /// <param name="chamber">Chamber of congress.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="Bill"/> or null if bill could not be found.</returns>
        public Bill GetBillByID(Chamber chamber, string id)
        {
            using (var client = new HttpClient())
            {
                var chamberString = EnumConvert.ChamberEnumToString(chamber);
                var url = string.Format(BillUrls.BillByID, chamberString, id);
                var result = client.Get<ResultWrapper<BillsWrapper<ApiBill>>>(url, _parent.Headers);
                return result?.Results?[0].Bills.Select(b => ApiBill.Convert(b, _parent.Cache[_parent.CurrentCongress])).FirstOrDefault();
            }
        }
    }
}
