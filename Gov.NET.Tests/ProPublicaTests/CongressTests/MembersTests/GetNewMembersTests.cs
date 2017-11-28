using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class GetNewMembersTests : IClassFixture<NewMembersFixture>
    {
        
        public NewMembersFixture Fixture { get; }

        public GetNewMembersTests(NewMembersFixture fixture)
        {
            this.Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.PoliticianCards);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.PoliticianCards);
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            foreach (var member in Fixture.PoliticianCards)
                Assert.NotNull(member);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var member in Fixture.PoliticianCards)
                Assert.False(string.IsNullOrEmpty(member.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var member in Fixture.PoliticianCards)
                Assert.False(string.IsNullOrEmpty(member.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var member in Fixture.PoliticianCards)
                Assert.False(string.IsNullOrEmpty(member.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var member in Fixture.PoliticianCards)
                Assert.False(string.IsNullOrEmpty(member.ID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var member in Fixture.PoliticianCards)
                Assert.NotNull(member.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            foreach (var member in Fixture.PoliticianCards)
                Assert.False(string.IsNullOrEmpty(member.Party));
        }
    }
}