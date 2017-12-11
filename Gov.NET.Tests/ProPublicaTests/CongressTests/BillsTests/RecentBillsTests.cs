using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.BillsTests
{
    public class RecentBillsTests : IClassFixture<RecentBillsFixture>
    {
        public RecentBillsFixture Fixture { get; }

        public RecentBillsTests(RecentBillsFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.RecentBills);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.RecentBills);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in Fixture.RecentBills)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in Fixture.RecentBills)
                Assert.False(string.IsNullOrEmpty(bill.ID));
        }

        [Fact]
        public void BillsHaveAnTitle()
        {
            foreach (var bill in Fixture.RecentBills)
                Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillsHaveText()
        {
            foreach (var bill in Fixture.RecentBills)
                Assert.False(string.IsNullOrEmpty(bill.Text));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in Fixture.RecentBills)
                Assert.NotNull(bill.Chamber);
        }
    }
}