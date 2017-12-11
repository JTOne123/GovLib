using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.BillsTests
{
    public class RecentBillsFixture : CongressFixture
    {
        public Bill[] RecentBills { get; }

        public RecentBillsFixture()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            RecentBills = Congress.Bills.GetRecentBills(Chamber.Senate, 115, BillStatus.Passed);
        }
    }
}