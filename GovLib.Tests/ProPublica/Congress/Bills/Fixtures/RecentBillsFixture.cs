using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    public class RecentBillsFixture : CongressFixture
    {
        public Bill[] RecentBills { get; }

        public RecentBillsFixture()
        {
            RecentBills = Congress.Bills.GetRecentBills(Chamber.Senate, 115, BillStatus.Passed);
        }
    }
}