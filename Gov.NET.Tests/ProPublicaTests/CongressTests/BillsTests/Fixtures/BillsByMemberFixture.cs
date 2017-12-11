using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.BillsTests
{
    public class BillsByMemberFixture : CongressFixture
    {
        public Bill[] BillsByMember { get; }

        public BillsByMemberFixture()
        {
            BillsByMember = Congress.Bills.GetRecentBillsByMember("L000287");
        }
    }
}