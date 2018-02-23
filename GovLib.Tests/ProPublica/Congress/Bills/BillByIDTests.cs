using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("MainTestCollection")]
    public class BillByIDTests : IClassFixture<CongressFixture>
    {
        public Bill BillByID { get; }

        public BillByIDTests(CongressFixture fixture)
        {
            BillByID = fixture.Congress.Bills.GetBillByID(115, "hr21");
        }

        [Fact]
        public void BillIsNotNull()
        {
            Assert.NotNull(BillByID);
        }

        [Fact]
        public void BillHasAnID()
        {
            Assert.False(string.IsNullOrEmpty(BillByID.BillID));
        }

        [Fact]
        public void BillHasAType()
        {
            Assert.False(string.IsNullOrEmpty(BillByID.BillType));
        }

        [Fact]
        public void BillHasATitle()
        {
            Assert.False(string.IsNullOrEmpty(BillByID.Title));
        }

        [Fact]
        public void BillHasAChamber()
        {
            Assert.NotNull(BillByID.Chamber);
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            Assert.Equal(BillByID.SponsorID, BillByID.Sponsor.CongressID);
        }

        [Fact]
        public void BillHasAnIntroducedDate()
        {
            Assert.NotNull(BillByID.Introduced);
        }

        [Fact]
        public void BillHasALatestAction()
        {
            Assert.False(string.IsNullOrEmpty(BillByID.LatestAction));
        }

        [Fact]
        public void BillHasALatestActionDate()
        {
            Assert.NotNull(BillByID.LatestActionDate);
        }

        [Fact]
        public void BillHasAUrl()
        {
            Assert.NotNull(BillByID.Url);
        }
    }
}