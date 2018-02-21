using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("BillTestCollection")]
    public class BillAmmendmentTests : IClassFixture<CongressFixture>
    {
        public Ammendment[] BillAmmendments { get; }

        public BillAmmendmentTests(CongressFixture fixture)
        {
            BillAmmendments = fixture.Congress.Bills.GetBillAmmendments(115, "hr21");
        }

        [Fact]
        public void AmmendmentIsNotNull()
        {
            Assert.NotNull(BillAmmendments);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(BillAmmendments);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(BillAmmendments);
        }

        [Fact]
        public void AmmendmentsAreNotNull()
        {
            foreach (var ammendment in BillAmmendments)
                Assert.NotNull(ammendment);
        }

        [Fact]
        public void AmmendmentsHaveANumber()
        {
            foreach (var ammendment in BillAmmendments)
                Assert.False(string.IsNullOrEmpty(ammendment.Slug));
        }

        [Fact]
        public void AmmendmentsHaveATitle()
        {
            foreach (var ammendment in BillAmmendments)
                Assert.False(string.IsNullOrEmpty(ammendment.Title));
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            foreach (var ammendment in BillAmmendments)
                Assert.Equal(ammendment.SponsorID, ammendment.Sponsor.CongressID);
        }

        [Fact]
        public void BillsHaveAnIntroducedDate()
        {
            foreach (var ammendment in BillAmmendments)
                Assert.NotNull(ammendment.Introduced);
        }
    }
}