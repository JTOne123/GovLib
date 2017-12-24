using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.BillsTests
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