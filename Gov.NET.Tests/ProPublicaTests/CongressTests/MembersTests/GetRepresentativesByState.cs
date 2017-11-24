using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class GetRepresentativesByStateTests : IClassFixture<RepresentativesByStateFixture>
    {
        
        public RepresentativesByStateFixture Fixture { get; }

        public GetRepresentativesByStateTests(RepresentativesByStateFixture fixture)
        {
            this.Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.RepresentativeCards);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.RepresentativeCards);
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            foreach (var member in Fixture.RepresentativeCards)
                Assert.NotNull(member);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var member in Fixture.RepresentativeCards)
                Assert.False(string.IsNullOrEmpty(member.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var member in Fixture.RepresentativeCards)
                Assert.False(string.IsNullOrEmpty(member.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var member in Fixture.RepresentativeCards)
                Assert.False(string.IsNullOrEmpty(member.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var member in Fixture.RepresentativeCards)
                Assert.False(string.IsNullOrEmpty(member.ID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var member in Fixture.RepresentativeCards)
                Assert.False(string.IsNullOrEmpty(member.State));
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            foreach (var member in Fixture.RepresentativeCards)
                Assert.False(string.IsNullOrEmpty(member.Party));
        }
    }
}