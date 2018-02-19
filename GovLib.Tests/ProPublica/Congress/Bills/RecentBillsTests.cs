using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("BillTestCollection")]
    public class RecentBillsTests : IClassFixture<CongressFixture>
    {
        public Bill[] RecentBills { get; }

        public RecentBillsTests(CongressFixture fixture)
        {
            RecentBills = fixture.Congress.Bills.GetRecentBills(Chamber.Senate, BillStatus.Passed, 115);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(RecentBills);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(RecentBills);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in RecentBills)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in RecentBills)
                Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillsHaveATitle()
        {
            foreach (var bill in RecentBills)
                Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in RecentBills)
                Assert.NotNull(bill.Chamber);
        }

        [Fact]
        public void BillsHaveAnIntroducedDate()
        {
            foreach (var bill in RecentBills)
                Assert.NotNull(bill.Introduced);
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            foreach (var bill in RecentBills)
                Assert.Equal(bill.SponsorID, bill.Sponsor.CongressID);
        }
    }
}