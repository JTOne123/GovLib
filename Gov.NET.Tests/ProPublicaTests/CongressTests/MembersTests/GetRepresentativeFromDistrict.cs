using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class GetRepresentativesFromDistrictTests : IClassFixture<RepresentativeFromDistrictFixture>
    {
        
        public RepresentativeFromDistrictFixture Fixture { get; }

        public GetRepresentativesFromDistrictTests(RepresentativeFromDistrictFixture fixture)
        {
            this.Fixture = fixture;
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            Assert.NotNull(Fixture.RepresentativeCard);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.RepresentativeCard.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.RepresentativeCard.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.RepresentativeCard.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.RepresentativeCard.ID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.RepresentativeCard.State));
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.RepresentativeCard.Party));
        }
    }
}