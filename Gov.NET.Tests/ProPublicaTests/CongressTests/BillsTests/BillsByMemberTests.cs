using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.BillsTests
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
                Assert.False(string.IsNullOrEmpty(bill.ID));
        }

        [Fact]
        public void BillsHaveAnTitle()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.False(string.IsNullOrEmpty(bill.Title));
        }

        [Fact]
        public void BillsHaveText()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.False(string.IsNullOrEmpty(bill.Text));
        }

        [Fact]
        public void BillsHaveAChamber()
        {
            foreach (var bill in Fixture.BillsByMember)
                Assert.NotNull(bill.Chamber);
        }
    }
}