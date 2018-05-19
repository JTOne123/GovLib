using System;
using GovLib.ProPublica.Urls;
using GovLib.Util;
using static GovLib.Util.EnumConvert;

namespace GovLib.ProPublica.Builders
{
    internal class BillUrlBuilder : IBillUrlBuilder
    {
        public string RecentBills(Chamber chamber, BillStatus status, int congressNum) =>
            string.Format(BillUrls.RecentBills, ChamberEnumToString(chamber), BillStatusEnumToString(status), congressNum.ToString());
        public string BillsByMember(string congressID) =>
            string.Format(BillUrls.BillsByMember, congressID);
        public string BillsBySubject(string subject) =>
            string.Format(BillUrls.BillsBySubject, subject);
        public string UpcomingBills(Chamber chamber) =>
            string.Format(BillUrls.UpcomingBills, ChamberEnumToString(chamber));
        public string BillByID(int congressNum, string id) =>
            string.Format(BillUrls.BillByID, congressNum, id);
        public string BillAmmendments(int congressNum, string id) =>
            string.Format(BillUrls.BillAmmendments, congressNum, id);
        public string BillSubjects(int congressNum, string id) =>
            string.Format(BillUrls.BillSubjects, congressNum, id);
        public string RelatedBills(int congressNum, string id) =>
            string.Format(BillUrls.RelatedBills, congressNum, id);
        public string SubjectsByTerm(string term) =>
            string.Format(BillUrls.Subjects, term);
        public string Cosponsors(int congressNum, string id) =>
            string.Format(BillUrls.Cosponsors, congressNum, id);
    }
}