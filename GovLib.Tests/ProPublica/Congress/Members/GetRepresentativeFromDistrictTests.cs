using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("ProPublica Test Collection")]
    public class GetRepresentativeFromDistrictTests : IClassFixture<CongressFixture>
    {
        public RepresentativeSummary DistrictRep { get; }

        public GetRepresentativeFromDistrictTests(CongressFixture fixture)
        {
            // John Lewis
            DistrictRep = fixture.Congress.Members.GetRepresentiveFromDistrict(State.Georgia, 6);
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            Assert.NotNull(DistrictRep);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            Assert.False(string.IsNullOrEmpty(DistrictRep.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            Assert.False(string.IsNullOrEmpty(DistrictRep.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            Assert.False(string.IsNullOrEmpty(DistrictRep.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            Assert.False(string.IsNullOrEmpty(DistrictRep.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            Assert.NotNull(DistrictRep.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            Assert.False(string.IsNullOrEmpty(DistrictRep.Party));
        }
    }
}