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
using Newtonsoft.Json;
using GovLib.ProPublica.Builders;

namespace GovLib.ProPublica.Modules
{
    /// <summary>
    /// Get information about bills introduced to congress.
    /// </summary>
    public class BillsApi
    {
        private Congress _congress { get; }
        private IBillUrlBuilder _billUrlBuilder { get; }

        internal BillsApi(Congress parent, IBillUrlBuilder billUrlBuilder)
        {
            _congress = parent;
            _billUrlBuilder = billUrlBuilder;
        }

        /// <summary>
        /// Get the 20 most recent bills by type in the current congress session.
        /// </summary>
        /// <param name="chamber"><see cref="Chamber" /></param>
        /// <param name="status"><see cref="BillStatus" /></param>
        /// <returns><see cref="Bill" /> array.</returns>
        public IEnumerable<Bill> GetRecentBills(Chamber chamber, BillStatus status)
        {
            return GetRecentBills(chamber, status, _congress.CurrentCongress);
        }

        /// <summary>
        /// Get the 20 most recent bills by type in the current congress session
        /// or the 20 last bills of a previous session.
        /// </summary>
        /// <param name="chamber"><see cref="Chamber" /></param>
        /// <param name="status"><see cref="BillStatus" /></param>
        /// <param name="congressNum">Congress number</param>
        /// <returns><see cref="Bill" /> array.</returns>
        public IEnumerable<Bill> GetRecentBills(Chamber chamber, BillStatus status, int congressNum)
        {
            var url = _billUrlBuilder.RecentBills(chamber, status, congressNum);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<BillsWrapper<ApiBill>>>(result);
            return json?.Results?[0].Bills.Select(bill => ApiBill.Convert(bill));
        }

        /// <summary>
        /// Get the 20 bills most recently introduced or updated by a particular member.
        /// </summary>
        /// <param name="congressNumMember"><see cref="ICongressMember" /></param>
        /// <returns><see cref="Bill" /> array.</returns>
        public IEnumerable<Bill> GetRecentBillsByMember(ICongressMember congressNumMember)
        {
            return GetRecentBillsByMember(congressNumMember.CongressID);
        }


        /// <summary>
        /// Get the 20 bills most recently introduced or updated by a particular member.
        /// </summary>
        /// <param name="id">Congress member bio ID.</param>
        /// <returns><see cref="Bill" /> array.</returns>
        public IEnumerable<Bill> GetRecentBillsByMember(string id)
        {
            var url = _billUrlBuilder.BillsByMember(id);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<BillsWrapper<ApiBill>>>(result);
            return json?.Results?[0].Bills.Select(bill => ApiBill.Convert(bill));
        }

        /// <summary>
        /// Get the 20 most recently updated bills for a specific legislative subject.
        /// </summary>
        /// <param name="subject"><see cref="BillSubject" /></param>
        /// <returns><see cref="Bill"/>array.</returns>
        public IEnumerable<Bill> GetRecentBillsBySubject(BillSubject subject)
        {
            return GetRecentBillsBySubject(subject.Name);
        }

        /// <summary>
        /// Get the 20 most recently updated bills for a specific legislative subject.
        /// </summary>
        /// <param name="subject">Search term.</param>
        /// <returns><see cref="Bill"/>array.</returns>
        public IEnumerable<Bill> GetRecentBillsBySubject(string subject)
        {
            var url = _billUrlBuilder.BillsBySubject(subject);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<ApiBill>>(result);
            return json?.Results?.Select(b => ApiBill.Convert(b));
        }

        /// <summary>
        /// Get bills that may be considered in the near future.
        /// </summary>
        /// <param name="chamber"><see cref="Chamber" /></param>
        /// <returns><see cref="BillSummary"/>array.</returns>
        public IEnumerable<BillSummary> GetUpcomingBills(Chamber chamber)
        {
            var url = _billUrlBuilder.UpcomingBills(chamber);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<BillsWrapper<ApiUpcomingBills>>>(result);
            return json?.Results?[0].Bills.Select(b => ApiUpcomingBills.Convert(b));
        }

        /// <summary>
        /// Get specific bill by ID.
        /// </summary>
        /// <param name="congressNum">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="Bill"/></returns>
        public Bill GetBillByID(int congressNum, string id)
        {
            var url = _billUrlBuilder.BillByID(congressNum, id);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<ApiBill>>(result);
            return ApiBill.Convert(json?.Results?.FirstOrDefault());
        }

        /// <summary>
        /// Get amendments for a specific bill.
        /// </summary>
        /// <param name="congressNum">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="Amendment"/>array.</returns>
        public IEnumerable<Amendment> GetBillAmendments(int congressNum, string id)
        {
            var url = _billUrlBuilder.BillAmmendments(congressNum, id);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<AmendmentsWrapper<ApiAmendment>>>(result);
            return json?.Results?[0].Amendments.Select(a => ApiAmendment.Convert(a));
        }

        /// <summary>
        /// Get subjects for a specific bill.
        /// </summary>
        /// <param name="congressNum">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="BillSubject"/>array.</returns>
        public IEnumerable<BillSubject> GetBillSubjects(int congressNum, string id)
        {
            var url = _billUrlBuilder.BillSubjects(congressNum, id);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<SubjectsWrapper<ApiSubject>>>(result);
            return json?.Results?[0].Subjects.Select(s => ApiSubject.Convert(s));
        }

        /// <summary>
        /// Get bills related to a specific bill.
        /// </summary>
        /// <param name="congressNum">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns><see cref="Bill"/>array.</returns>
        public IEnumerable<Bill> GetRelatedBills(int congressNum, string id)
        {
            var url = _billUrlBuilder.RelatedBills(congressNum, id);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<RelatedBillsWrapper<ApiBill>>>(result);
            return json?.Results?[0].RelatedBills.Select(b => ApiBill.Convert(b));
        }

        /// <summary>
        /// Get subjects related to given search term.
        /// </summary>
        /// <param name="term">Term to search for.</param>
        /// <returns><see cref="BillSubject"/>array.</returns>
        public IEnumerable<BillSubject> GetSubjectsByTerm(string term)
        {
            var headers = new Dictionary<string, string>(_congress.Headers);
            headers.Add("query", term);
            var result = _congress.Client.Get(_billUrlBuilder.SubjectsByTerm(term), headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<SubjectsWrapper<ApiSubject>>>(result);
            return json?.Results?[0].Subjects.Select(s => ApiSubject.Convert(s));
        }

        /// <summary>
        /// Get cosponsrs for a specific bill.
        /// </summary>
        /// <param name="congressNum">Congress number.</param>
        /// <param name="id">Bill ID.</param>
        /// <returns>Cosponsor CongressID array.</returns>
        public IEnumerable<string> GetBillCosponsors(int congressNum, string id)
        {
            var url = _billUrlBuilder.Cosponsors(congressNum, id);
            var result = _congress.Client.Get(url, _congress.Headers);
            var json = JsonConvert.DeserializeObject<ResultWrapper<CosponsorsWrapper<ApiCosponsor>>>(result);
            return json?.Results?[0].Cosponsors.Select(c => c.ID);
        }
    }
}
