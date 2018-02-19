using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    public class BillsBySubjectFixture : CongressFixture
    {
        public Bill[] BillsBySubject { get; }

        public BillsBySubjectFixture()
        {
            BillsBySubject = Congress.Bills.GetRecentBillsBySubject("meat");
        }
    }
}