using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    [Collection("MainTestCollection")]
    public class BillsBySubjectTests : IClassFixture<CongressFixture>
    {
        public Bill[] BillsBySubject { get; }

        public BillsBySubjectTests(CongressFixture fixture)
        {
            BillsBySubject = fixture.Congress.Bills.GetRecentBillsBySubject("meat");
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(BillsBySubject);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(BillsBySubject);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in BillsBySubject)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in BillsBySubject)
                Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillsHaveATitle()
        {
            foreach (var bill in BillsBySubject)
                Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in BillsBySubject)
                Assert.NotNull(bill.Chamber);
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            foreach (var bill in BillsBySubject)
                Assert.Equal(bill.SponsorID, bill.Sponsor.CongressID);
        }

        [Fact]
        public void BillsHaveAnIntroducedDate()
        {
            foreach (var bill in BillsBySubject)
                Assert.NotNull(bill.Introduced);
        }
    }
}