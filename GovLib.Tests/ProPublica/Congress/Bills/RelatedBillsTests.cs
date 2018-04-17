using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("ProPublica Test Collection")]
    public class RelatedBillsTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<Bill> RelatedBills { get; }

        public RelatedBillsTests(CongressFixture fixture)
        {
            RelatedBills = fixture.Congress.Bills.GetRelatedBills(115, "hr3219");
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(RelatedBills);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(RelatedBills);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in RelatedBills)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in RelatedBills)
                Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillsHaveATitle()
        {
            foreach (var bill in RelatedBills)
                Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in RelatedBills)
                Assert.NotNull(bill.Chamber);
        }

        [Fact]
        public void BillsHaveAnIntroducedDate()
        {
            foreach (var bill in RelatedBills)
                Assert.NotNull(bill.Introduced);
        }
    }
}