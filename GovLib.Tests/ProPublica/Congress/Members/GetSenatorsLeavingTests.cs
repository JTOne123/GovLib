using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class GetSenatorsLeavingTests : IClassFixture<SenatorsLeavingFixture>
    {
        
        public SenatorsLeavingFixture Fixture { get; }

        public GetSenatorsLeavingTests(SenatorsLeavingFixture fixture)
        {
            this.Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.Senators);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.Senators);
        }

        [Fact]
        public void SenatorCardsAreNotNull()
        {
            foreach (var senatorCard in Fixture.Senators)
                Assert.NotNull(senatorCard);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var senatorCard in Fixture.Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var senatorCard in Fixture.Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var senatorCard in Fixture.Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var senatorCard in Fixture.Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var senatorCard in Fixture.Senators)
                Assert.NotNull(senatorCard.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            foreach (var senatorCard in Fixture.Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.Party));
        }
    }
}