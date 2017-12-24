using Xunit;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class GetSenatorsByStateTests : IClassFixture<SenatorsByStateFixture>
    {
        
        public SenatorsByStateFixture Fixture { get; }

        public GetSenatorsByStateTests(SenatorsByStateFixture fixture)
        {
            this.Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.SenatorCards);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.SenatorCards);
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            foreach (var member in Fixture.SenatorCards)
                Assert.NotNull(member);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var member in Fixture.SenatorCards)
                Assert.False(string.IsNullOrEmpty(member.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var member in Fixture.SenatorCards)
                Assert.False(string.IsNullOrEmpty(member.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var member in Fixture.SenatorCards)
                Assert.False(string.IsNullOrEmpty(member.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var member in Fixture.SenatorCards)
                Assert.False(string.IsNullOrEmpty(member.ID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var member in Fixture.SenatorCards)
                Assert.NotNull(member.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            foreach (var member in Fixture.SenatorCards)
                Assert.False(string.IsNullOrEmpty(member.Party));
        }
    }
}