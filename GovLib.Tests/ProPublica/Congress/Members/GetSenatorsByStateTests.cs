using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
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
            Assert.NotNull(Fixture.StateSenators);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.StateSenators);
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            foreach (var member in Fixture.StateSenators)
                Assert.NotNull(member);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var member in Fixture.StateSenators)
                Assert.False(string.IsNullOrEmpty(member.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var member in Fixture.StateSenators)
                Assert.False(string.IsNullOrEmpty(member.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var member in Fixture.StateSenators)
                Assert.False(string.IsNullOrEmpty(member.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var member in Fixture.StateSenators)
                Assert.False(string.IsNullOrEmpty(member.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var member in Fixture.StateSenators)
                Assert.NotNull(member.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            foreach (var member in Fixture.StateSenators)
                Assert.False(string.IsNullOrEmpty(member.Party));
        }
    }
}