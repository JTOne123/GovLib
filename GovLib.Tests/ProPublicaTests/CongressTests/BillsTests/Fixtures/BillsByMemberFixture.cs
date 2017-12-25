using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.BillsTests
{
    public class BillsByMemberFixture : CongressFixture
    {
        public Bill[] BillsByMember { get; }

        public BillsByMemberFixture()
        {
            BillsByMember = Congress.BillsApi.GetRecentBillsByMember("L000287");
        }
    }
}