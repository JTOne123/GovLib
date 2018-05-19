using System.IO;
using System.Reflection;
using GovLib.ProPublica.Urls;
using static GovLib.Util.EnumConvert;

namespace GovLib.ProPublica.Builders
{
    internal class TestBillUrlBuilder : IBillUrlBuilder
    {
        private readonly string _billPath;

        internal TestBillUrlBuilder()
        {
            var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            _billPath = Path.Combine(assemblyPath, "ProPublica", "Bills");
        }
        
        public string RecentBills(Chamber chamber, BillStatus status, int congressNum) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.RecentBills, ChamberEnumToString(chamber)));
        
        public string BillsByMember(string congressID) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.BillsByMember, congressID));
        
        public string BillsBySubject(string subject) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.BillsBySubject, subject));
        
        public string UpcomingBills(Chamber chamber) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.UpcomingBills, ChamberEnumToString(chamber)));
        
        public string BillByID(int congressNum, string id) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.BillByID, id));
        
        public string BillAmmendments(int congressNum, string id) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.BillAmmendments, id));
        
        public string BillSubjects(int congressNum, string id) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.BillSubjects, id));
        
        public string RelatedBills(int congressNum, string id) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.RelatedBills, id));
        
        public string SubjectsByTerm(string term) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.SubjectsByTerm, term));
        
        public string Cosponsors(int congressNum, string id) =>
            Path.Combine(_billPath, string.Format(TestBillUrls.Cosponsors, id));
        
    }
}