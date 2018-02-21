using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("BillTestCollection")]
    public class BillAmendmentTests : IClassFixture<CongressFixture>
    {
        public Amendment[] BillAmendments { get; }

        public BillAmendmentTests(CongressFixture fixture)
        {
            BillAmendments = fixture.Congress.Bills.GetBillAmendments(115, "hr21");
        }

        [Fact]
        public void AmendmentIsNotNull()
        {
            Assert.NotNull(BillAmendments);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(BillAmendments);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(BillAmendments);
        }

        [Fact]
        public void AmendmentsAreNotNull()
        {
            foreach (var ammendment in BillAmendments)
                Assert.NotNull(ammendment);
        }

        [Fact]
        public void AmendmentsHaveANumber()
        {
            foreach (var ammendment in BillAmendments)
                Assert.False(string.IsNullOrEmpty(ammendment.Slug));
        }

        [Fact]
        public void AmendmentsHaveATitle()
        {
            foreach (var ammendment in BillAmendments)
                Assert.False(string.IsNullOrEmpty(ammendment.Title));
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            foreach (var ammendment in BillAmendments)
                Assert.Equal(ammendment.SponsorID, ammendment.Sponsor.CongressID);
        }

        [Fact]
        public void BillsHaveAnIntroducedDate()
        {
            foreach (var ammendment in BillAmendments)
                Assert.NotNull(ammendment.Introduced);
        }
    }
}