using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    public class UpcomingBillsTests : IClassFixture<UpcomingBillsFixture>
    {
        public UpcomingBillsFixture Fixture { get; }

        public UpcomingBillsTests(UpcomingBillsFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.UpcomingBills);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.UpcomingBills);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in Fixture.UpcomingBills)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in Fixture.UpcomingBills)
                Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in Fixture.UpcomingBills)
                Assert.NotNull(bill.Chamber);
        }
    }
}