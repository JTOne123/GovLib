using Xunit;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
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
            Assert.NotNull(Fixture.DistrictRep);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.DistrictRep.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.DistrictRep.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.DistrictRep.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.DistrictRep.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            Assert.NotNull(Fixture.DistrictRep.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.DistrictRep.Party));
        }
    }
}