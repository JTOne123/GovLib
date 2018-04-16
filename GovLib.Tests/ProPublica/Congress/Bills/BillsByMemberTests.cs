using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("MainTestCollection")]
    public class BillsByMemberTests : IClassFixture<CongressFixture>
    {
        public Bill[] BillsByMember { get; }

        public BillsByMemberTests(CongressFixture fixture)
        {
            BillsByMember = fixture.Congress.Bills.GetRecentBillsByMember("L000287");
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(BillsByMember);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(BillsByMember);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in BillsByMember)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in BillsByMember)
                Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillsHaveATitle()
        {
            foreach (var bill in BillsByMember)
                Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in BillsByMember)
                Assert.NotNull(bill.Chamber);
        }

        [Fact]
        public void BillsHaveAnIntroducedDate()
        {
            foreach (var bill in BillsByMember)
                Assert.NotNull(bill.Introduced);
        }
    }
}