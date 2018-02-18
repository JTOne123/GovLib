using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    public class BillsBySubjectTests : IClassFixture<BillsBySubjectFixture>
    {
        public BillsBySubjectFixture Fixture { get; }

        public BillsBySubjectTests(BillsBySubjectFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.BillsBySubject);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.BillsBySubject);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in Fixture.BillsBySubject)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in Fixture.BillsBySubject)
                Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillsHaveATitle()
        {
            foreach (var bill in Fixture.BillsBySubject)
                Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in Fixture.BillsBySubject)
                Assert.NotNull(bill.Chamber);
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            foreach (var bill in Fixture.BillsBySubject)
                Assert.Equal(bill.SponsorID, bill.Sponsor.CongressID);
        }

        [Fact]
        public void BillsHaveAnIntroducedDate()
        {
            foreach (var bill in Fixture.BillsBySubject)
                Assert.NotNull(bill.Introduced);
        }
    }
}