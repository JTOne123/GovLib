using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("ProPublica Test Collection")]
    public class BillAmendmentsTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<Amendment> BillAmendments { get; }

        public BillAmendmentsTests(CongressFixture fixture)
        {
            BillAmendments = fixture.Congress.Bills.GetBillAmendments(115, "hr1628");
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
        public void AmendmentsHaveAnIntroducedDate()
        {
            foreach (var amendment in BillAmendments)
                Assert.NotNull(amendment.Introduced);
        }

        [Fact]
        public void AmendmentsHaveALatestAction()
        {
            foreach (var amendment in BillAmendments)
                Assert.False(string.IsNullOrEmpty(amendment.LatestAction));
        }

        [Fact]
        public void AmendmentsHaveALatestActionDate()
        {
            foreach (var amendment in BillAmendments)
                Assert.NotNull(amendment.LatestActionDate);
        }

        [Fact]
        public void AmendmentsHaveANumber()
        {
            foreach (var amendment in BillAmendments)
                Assert.NotNull(amendment.Number);
        }

        [Fact]
        public void AmendmentsHaveASlug()
        {
            foreach (var amendment in BillAmendments)
                Assert.NotNull(amendment.Slug);
        }

        [Fact]
        public void AmendmentsHaveATitle()
        {
            foreach (var amendment in BillAmendments)
                Assert.NotNull(amendment.Title);
        }
    }
}