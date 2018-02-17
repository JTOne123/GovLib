using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Bills
{
    public class BillsByMemberTests : IClassFixture<BillsByMemberFixture>
    {
        public BillsByMemberFixture Fixture { get; }

        public BillsByMemberTests(BillsByMemberFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.BillsByMember);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.BillsByMember);
        }

        [Fact]
        public void BillsAreNotNull()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.NotNull(bill);
        }

        [Fact]
        public void BillsHaveAnID()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.False(string.IsNullOrEmpty(bill.BillID));
        }

        [Fact]
        public void BillsHaveATitle()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.NotNull(bill.Chamber);
        }

        [Fact]
        public void BillSponsorIdMatchesSponsorObjectId()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.Equal(bill.SponsorID, bill.Sponsor.CongressID);
        }

        [Fact]
        public void BillsHaveAnIntroducedDate()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.NotNull(bill.Introduced);
        }
    }
}