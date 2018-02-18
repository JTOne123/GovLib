using System.Net;
using Newtonsoft.Json.Linq;
using GovLib.ProPublica.Urls;
using GovLib.Contracts;
using GovLib.ProPublica.Util.ApiModels.Wrappers;
using GovLib.Util;
using System.Linq;
using GovLib.ProPublica.Util.ApiModels.BillModels;
using GovLib.ProPublica.Util;
using System.Collections.Generic;

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
                var stringResult = client.Get<JObject>(url, _parent.Headers);
                var result = client.Get<ResultWrapper<ApiBill>>(url, _parent.Headers);
                return result?.Results?.Select(b => ApiBill.Convert(b, _parent.Cache[_parent.CurrentCongress])).ToArray();
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
        /// Get specific bill by ID.
        /// </summary>
        /// <param name="congress">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="Bill"/></returns>
        public Bill GetBillByID(int congress, string id)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(BillUrls.BillByID, congress, id);
                var result = client.Get<ResultWrapper<ApiBill>>(url, _parent.Headers);
                return result?.Results?.Select(b => ApiBill.Convert(b, _parent.Cache[_parent.CurrentCongress])).FirstOrDefault();
            }
        }

        /// <summary>
        /// Get ammendments for a specific bill.
        /// </summary>
        /// <param name="congress">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="Ammendment"/>array.</returns>
        public Ammendment[] GetBillAmmendments(int congress, string id)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(BillUrls.BillAmmendments, congress, id);
                var result = client.Get<ResultWrapper<AmmendmentsWrapper<ApiAmmendment>>>(url, _parent.Headers);
                return result?.Results?[0].Ammendments.Select(a => ApiAmmendment.Convert(a, _parent.Cache[congress])).ToArray();
            }
        }

        /// <summary>
        /// Get subjects for a specific bill.
        /// </summary>
        /// <param name="congress">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="BillSubject"/>array.</returns>
        public BillSubject[] GetBillSubjects(int congress, string id)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(BillUrls.BillSubjects, congress, id);
                var result = client.Get<ResultWrapper<SubjectsWrapper<ApiSubject>>>(url, _parent.Headers);
                return result?.Results?[0].Subjects.Select(s => ApiSubject.Convert(s)).ToArray();
            }
        }

        /// <summary>
        /// Get bills related to a specific bill.
        /// </summary>
        /// <param name="congress">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="Bill"/>array.</returns>
        public Bill[] GetRelatedBills(int congress, string id)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(BillUrls.RelatedBills, congress, id);
                var result = client.Get<ResultWrapper<RelatedBillsWrapper<ApiBill>>>(url, _parent.Headers);
                return result?.Results?[0].RelatedBills.Select(b => ApiBill.Convert(b, _parent.Cache[congress])).ToArray();
            }
        }

        /// <summary>
        /// Get subjects related to given search term.
        /// </summary>
        /// <param name="term">Term to search for.</param>
        /// <returns><see cref="BillSubject"/>array.</returns>
        public BillSubject[] GetSubjects(string term)
        {
            using (var client = new HttpClient())
            {
                var headers = new Dictionary<string, string>(_parent.Headers);
                headers.Add("query", term);
                var result = client.Get<ResultWrapper<SubjectsWrapper<ApiSubject>>>(BillUrls.Subjects, _parent.Headers);
                return result?.Results?[0].Subjects.Select(s => ApiSubject.Convert(s)).ToArray();
            }
        }

        /// <summary>
        /// Get cosponsrs for a specific bill.
        /// </summary>
        /// <param name="congress">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="Politician"/>array.</returns>
        public Politician[] GetBillCosponsors(int congress, string id)
        {
            using (var client = new HttpClient())
            {
                var url = string.Format(BillUrls.Cosponsors, congress, id);
                var result = client.Get<ResultWrapper<CosponsorsWrapper<ApiCosponsor>>>(url, _parent.Headers);
                return result?.Results?[0].Cosponsors.Select(c => ApiCosponsor.Convert(c, _parent.Cache[congress])).ToArray();
            }
        }
    }
}
