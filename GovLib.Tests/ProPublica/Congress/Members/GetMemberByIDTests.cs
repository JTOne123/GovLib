using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members.Fixtures
{
    [Collection("MemberTestCollection")]
    public class GetMemberByIDTests : IClassFixture<CongressFixture>
    {
        public Representative Representative { get; }
        public Senator Senator { get; }

        public GetMemberByIDTests(CongressFixture fixture)
        {
            Senator = fixture.Congress.Members.GetMemberByID("S000033") as Senator;
            Representative = fixture.Congress.Members.GetMemberByID("R000570") as Representative;
        }

        #region Representative Tests
        [Fact]
        public void RepresentativeIsNotNull()
        {
            Assert.NotNull(Representative);
        }

        [Fact]
        public void RepresentativeHasFirstName()
        {
            Assert.False(string.IsNullOrEmpty(Representative.FirstName));
        }

        [Fact]
        public void RepresentativeHasLastName()
        {
            Assert.False(string.IsNullOrEmpty(Representative.LastName));
        }

        [Fact]
        public void RepresentativeHasFullName()
        {
            Assert.False(string.IsNullOrEmpty(Representative.FullName));
        }

        [Fact]
        public void RepresentativeHasAnID()
        {
            Assert.False(string.IsNullOrEmpty(Representative.CongressID));
        }

        [Fact]
        public void RepresentativesHasAGender()
        {
            Assert.NotNull(Representative.Gender);
        }

        [Fact]
        public void RepresentativeHasAHomeState()
        {
            Assert.NotNull(Representative.State);
        }

        [Fact]
        public void RepresentativeHasAParty()
        {
            Assert.False(string.IsNullOrEmpty(Representative.Party));
        }

        [Fact]
        public void RepresentativeHasABirthDate()
        {
            Assert.False(string.IsNullOrEmpty(Representative.BirthDate.ToString()));
        }

        [Fact]
        public void RepresentativeInOfficeHasADistrict()
        {
            Assert.NotNull(Representative.District);
        }

        [Fact]
        public void RepresentativeInOfficeHasAnAtLargeBool()
        {
            Assert.NotNull(Representative.AtLargeDistrict);
        }

        [Fact]
        public void RepresentativeHasPartyLoyaltyRatio()
        {
            Assert.NotNull(Representative.PartyLoyaltyRatio);
        }

        [Fact]
        public void RepresentativeHasMissedVotesRatio()
        {
            Assert.NotNull(Representative.MissedVotesRatio);
        }
        #endregion

        #region Senator Tests
        [Fact]
        public void SenatorArentNull()
        {
            Assert.NotNull(Senator);
        }

        [Fact]
        public void SenatorHasFirstName()
        {
            Assert.False(string.IsNullOrEmpty(Senator.FirstName));
        }

        [Fact]
        public void SenatorHasLastName()
        {
            Assert.False(string.IsNullOrEmpty(Senator.LastName));
        }

        [Fact]
        public void SenatorHasFullName()
        {
            Assert.False(string.IsNullOrEmpty(Senator.FullName));
        }

        [Fact]
        public void SenatorHasAnID()
        {
            Assert.False(string.IsNullOrEmpty(Senator.CongressID));
        }

        [Fact]
        public void SenatorHasAGender()
        {
            Assert.NotNull(Senator.Gender);
        }

        [Fact]
        public void SenatorHasAHomeState()
        {
            Assert.NotNull(Senator.State);
        }

        [Fact]
        public void SenatorHasAParty()
        {
            Assert.False(string.IsNullOrEmpty(Senator.Party));
        }

        [Fact]
        public void SenatorHasABirthDate()
        {
            Assert.False(string.IsNullOrEmpty(Senator.BirthDate.ToString()));
        }

        [Fact]
        public void SenatorHasANextElection()
        {
            Assert.False(string.IsNullOrEmpty(Senator.NextElection.ToString()));
        }

        [Fact]
        public void SenatorHasASenateClass()
        {
            Assert.NotNull(Senator.Class);
            Assert.False(Senator.Class == 0);
        }

        [Fact]
        public void SenatorInOfficeHasAStateRank()
        {
            if (Senator.InOffice)
                Assert.False(string.IsNullOrEmpty(Senator.Rank));
        }

        [Fact]
        public void SenatorHasPartyLoyaltyRatio()
        {
            Assert.NotNull(Senator.PartyLoyaltyRatio);
        }

        [Fact]
        public void SenatorHasMissedVotesRatio()
        {
            Assert.NotNull(Senator.MissedVotesRatio);
        }
        #endregion
    }
}