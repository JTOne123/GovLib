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
            Assert.NotNull(Fixture.BillByID);
        }

        [Fact]
        public void BillHasAnID()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.BillByID.BillID));
        }

        [Fact]
        public void BillHasATitle()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.BillByID.Title));
        }

        [Fact]
        public void BillHasAChamber()
        {
            Assert.NotNull(Fixture.BillByID.Chamber);
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            Assert.Equal(Fixture.BillByID.SponsorID, Fixture.BillByID.Sponsor.CongressID);
        }

        [Fact]
        public void BillHasAnIntroducedDate()
        {
            Assert.NotNull(Fixture.BillByID.Introduced);
        }
    }
}