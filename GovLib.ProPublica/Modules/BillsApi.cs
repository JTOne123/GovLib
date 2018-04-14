// using System.Net;
// using Newtonsoft.Json.Linq;
// using GovLib.ProPublica.Urls;
// using GovLib.Contracts;
// using GovLib.ProPublica.Util.ApiModels.Wrappers;
// using GovLib.Util;
// using System.Linq;
// using GovLib.ProPublica.Util.ApiModels.BillModels;
// using GovLib.ProPublica.Util;
// using System.Collections.Generic;
// using Newtonsoft.Json;

// namespace GovLib.ProPublica.Modules
// {
//     /// <summary>
//     /// Get information about bills introduced to congress.
//     /// </summary>
//     public class BillsApi
//     {
//         private Congress _parent { get; }

//         internal BillsApi(Congress parent)
//         {
//             _parent = parent;
//         }

//         /// <summary>
//         /// Get the 20 most recent bills by type in the current congress session.
//         /// </summary>
//         /// <param name="chamber"><see cref="Chamber" /></param>
//         /// <param name="status"><see cref="BillStatus" /></param>
//         /// <returns><see cref="Bill" /> array.</returns>
//         public Bill[] GetRecentBills(Chamber chamber, BillStatus status)
//         {
//             return GetRecentBills(chamber, status, _parent.CurrentCongress);
//         }

//         /// <summary>
//         /// Get the 20 most recent bills by type in the current congress session
//         /// or the 20 last bills of a previous session.
//         /// </summary>
//         /// <param name="chamber"><see cref="Chamber" /></param>
//         /// <param name="status"><see cref="BillStatus" /></param>
//         /// <param name="congressNum">Congress number</param>
//         /// <returns><see cref="Bill" /> array.</returns>
//         public Bill[] GetRecentBills(Chamber chamber, BillStatus status, int congressNum)
//         {
//             using (var client = new HttpClient())
//             {
//                 var chamberString = EnumConvert.ChamberEnumToString(chamber);
//                 var statusString = EnumConvert.BillStatusEnumToString(status);
//                 var url = string.Format(BillUrls.RecentBills, congressNum, chamberString, statusString);
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<BillsWrapper<ApiBill>>>(result);
//                 return json?.Results?[0].Bills.Select(b => ApiBill.Convert(b, _parent.Cache[congressNum])).ToArray();
//             }
//         }

//         /// <summary>
//         /// Get the 20 bills most recently introduced or updated by a particular member.
//         /// </summary>
//         /// <param name="congressNumMember"><see cref="ICongressMember" /></param>
//         /// <returns><see cref="Bill" /> array.</returns>
//         public Bill[] GetRecentBillsByMember(ICongressMember congressNumMember)
//         {
//             return GetRecentBillsByMember(congressNumMember.CongressID);
//         }


//         /// <summary>
//         /// Get the 20 bills most recently introduced or updated by a particular member.
//         /// </summary>
//         /// <param name="id">Congress member bio ID.</param>
//         /// <returns><see cref="Bill" /> array.</returns>
//         public Bill[] GetRecentBillsByMember(string id)
//         {
//             using (var client = new HttpClient())
//             {
//                 var url = string.Format(BillUrls.MemberBills, id, "introduced");
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<BillsWrapper<ApiBill>>>(result);
//                 return json?.Results?[0].Bills.Select(b => ApiBill.Convert(b, _parent.Cache[_parent.CurrentCongress])).ToArray();
//             }
//         }

//         /// <summary>
//         /// Get the 20 most recently updated bills for a specific legislative subject.
//         /// </summary>
//         /// <param name="subject"><see cref="BillSubject" /></param>
//         /// <returns><see cref="Bill"/>array.</returns>
//         public Bill[] GetRecentBillsBySubject(BillSubject subject)
//         {
//             return GetRecentBillsBySubject(subject.Name);
//         }

//         /// <summary>
//         /// Get the 20 most recently updated bills for a specific legislative subject.
//         /// </summary>
//         /// <param name="subject">Search term.</param>
//         /// <returns><see cref="Bill"/>array.</returns>
//         public Bill[] GetRecentBillsBySubject(string subject)
//         {
//             using (var client = new HttpClient())
//             {
//                 var url = string.Format(BillUrls.BillsBySubject, subject);
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<ApiBill>>(result);
//                 return json?.Results?.Select(b => ApiBill.Convert(b, _parent.Cache[_parent.CurrentCongress])).ToArray();
//             }
//         }

//         /// <summary>
//         /// Get bills that may be considered in the near future.
//         /// </summary>
//         /// <param name="chamber"><see cref="Chamber" /></param>
//         /// <returns><see cref="BillSummary"/>array.</returns>
//         public BillSummary[] GetUpcomingBills(Chamber chamber)
//         {
//             using (var client = new HttpClient())
//             {
//                 var chamberString = EnumConvert.ChamberEnumToString(chamber);
//                 var url = string.Format(BillUrls.UpcomingBills, chamberString);
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<BillsWrapper<ApiUpcomingBills>>>(result);
//                 return json?.Results?[0].Bills.Select(b => ApiUpcomingBills.Convert(b)).ToArray();
//             }
//         }

//         /// <summary>
//         /// Get specific bill by ID.
//         /// </summary>
//         /// <param name="congressNum">Congress number.</param>
//         /// <param name="id">Bill ID.</param>
//         /// <returns><see cref="Bill"/></returns>
//         public Bill GetBillByID(int congressNum, string id)
//         {
//             using (var client = new HttpClient())
//             {
//                 var url = string.Format(BillUrls.BillByID, congressNum, id);
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<ApiBill>>(result);
//                 return ApiBill.Convert(json?.Results?.FirstOrDefault(), _parent.Cache[_parent.CurrentCongress]);
//             }
//         }

//         /// <summary>
//         /// Get amendments for a specific bill.
//         /// </summary>
//         /// <param name="congressNum">Congress number.</param>
//         /// <param name="id">Bill ID.</param>
//         /// <returns><see cref="Amendment"/>array.</returns>
//         public Amendment[] GetBillAmendments(int congressNum, string id)
//         {
//             using (var client = new HttpClient())
//             {
//                 var url = string.Format(BillUrls.BillAmmendments, congressNum, id);
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<AmendmentsWrapper<ApiAmendment>>>(result);
//                 return json?.Results?[0].Amendments.Select(a => ApiAmendment.Convert(a, _parent.Cache[congressNum])).ToArray();
//             }
//         }

//         /// <summary>
//         /// Get subjects for a specific bill.
//         /// </summary>
//         /// <param name="congressNum">Congress number.</param>
//         /// <param name="id">Bill ID.</param>
//         /// <returns><see cref="BillSubject"/>array.</returns>
//         public BillSubject[] GetBillSubjects(int congressNum, string id)
//         {
//             using (var client = new HttpClient())
//             {
//                 var url = string.Format(BillUrls.BillSubjects, congressNum, id);
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<SubjectsWrapper<ApiSubject>>>(result);
//                 return json?.Results?[0].Subjects.Select(s => ApiSubject.Convert(s)).ToArray();
//             }
//         }

//         /// <summary>
//         /// Get bills related to a specific bill.
//         /// </summary>
//         /// <param name="congressNum">Congress number.</param>
//         /// <param name="id">Bill ID.</param>
//         /// <returns><see cref="Bill"/>array.</returns>
//         public Bill[] GetRelatedBills(int congressNum, string id)
//         {
//             using (var client = new HttpClient())
//             {
//                 var url = string.Format(BillUrls.RelatedBills, congressNum, id);
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<RelatedBillsWrapper<ApiBill>>>(result);
//                 return json?.Results?[0].RelatedBills.Select(b => ApiBill.Convert(b, _parent.Cache[congressNum])).ToArray();
//             }
//         }

//         /// <summary>
//         /// Get subjects related to given search term.
//         /// </summary>
//         /// <param name="term">Term to search for.</param>
//         /// <returns><see cref="BillSubject"/>array.</returns>
//         public BillSubject[] GetSubjects(string term)
//         {
//             using (var client = new HttpClient())
//             {
//                 var headers = new Dictionary<string, string>(_parent.Headers);
//                 headers.Add("query", term);
//                 var result = _parent.Client.Get(BillUrls.Subjects, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<SubjectsWrapper<ApiSubject>>>(result);
//                 return json?.Results?[0].Subjects.Select(s => ApiSubject.Convert(s)).ToArray();
//             }
//         }

//         /// <summary>
//         /// Get cosponsrs for a specific bill.
//         /// </summary>
//         /// <param name="congressNum">Congress number.</param>
//         /// <param name="id">Bill ID.</param>
//         /// <returns><see cref="Politician"/>array.</returns>
//         public Politician[] GetBillCosponsors(int congressNum, string id)
//         {
//             using (var client = new HttpClient())
//             {
//                 var url = string.Format(BillUrls.Cosponsors, congressNum, id);
//                 var result = _parent.Client.Get(url, _parent.Headers);
//                 var json = JsonConvert.DeserializeObject<ResultWrapper<CosponsorsWrapper<ApiCosponsor>>>(result);
//                 return json?.Results?[0].Cosponsors.Select(c => ApiCosponsor.Convert(c, _parent.Cache[congressNum])).ToArray();
//             }
//         }
//     }
// }
