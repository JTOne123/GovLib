using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("BillTestCollection")]
    public class UpcomingBillsTests : IClassFixture<CongressFixture>
    {
        public BillSummary[] UpcomingBills { get; }

        public UpcomingBillsTests(CongressFixture fixture)
        {
            UpcomingBills = fixture.Congress.Bills.GetUpcomingBills(Chamber.House);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(UpcomingBills);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(UpcomingBills);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in UpcomingBills)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in UpcomingBills)
                Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in UpcomingBills)
                Assert.NotNull(bill.Chamber);
        }
    }
}