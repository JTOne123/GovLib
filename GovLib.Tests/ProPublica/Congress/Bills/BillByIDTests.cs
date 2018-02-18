using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    public class BillByIDTests : IClassFixture<BillByIDFixture>
    {
        public BillByIDFixture Fixture { get; }

        public BillByIDTests(BillByIDFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void BillIsNotNull()
        {
            Assert.NotNull(bill);
        }

        [Fact]
        public void BillHasAnID()
        {
            Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillHasATitle()
        {
            Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillHasAChamber()
        {
            Assert.NotNull(bill.Chamber);
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            Assert.Equal(bill.SponsorID, bill.Sponsor.CongressID);
        }

        [Fact]
        public void BillHasAnIntroducedDate()
        {
            Assert.NotNull(bill.Introduced);
        }
    }
}