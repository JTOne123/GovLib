using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests.Fixtures
{
    public class GetMemberByIDTests : IClassFixture<MemberByIDFixture>
    {
        public MemberByIDFixture Fixture { get; }

        public GetMemberByIDTests(MemberByIDFixture fixture)
        {
            this.Fixture = fixture;
        }

        #region Representative Tests
        [Fact]
        public void RepresentativeIsNotNull()
        {
            Assert.NotNull(Fixture.Representative);
        }

        [Fact]
        public void RepresentativeHasFirstName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Representative.FirstName));
        }

        [Fact]
        public void RepresentativeHasLastName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Representative.LastName));
        }

        [Fact]
        public void RepresentativeHasFullName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Representative.FullName));
        }

        [Fact]
        public void RepresentativeHasAnID()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Representative.ID));
        }

        [Fact]
        public void RepresentativesHasAGender()
        {
            Assert.NotNull(Fixture.Representative.Gender);
        }

        [Fact]
        public void RepresentativeHasAHomeState()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Representative.State));
        }

        [Fact]
        public void RepresentativeHasAParty()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Representative.Party));
        }

        [Fact]
        public void RepresentativeHasABirthDate()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Representative.BirthDate.ToString()));
        }

        [Fact]
        public void RepresentativeInOfficeHasADistrict()
        {
            Assert.NotNull(Fixture.Representative.District);
        }

        [Fact]
        public void RepresentativeInOfficeHasAnAtLargeBool()
        {
            Assert.NotNull(Fixture.Representative.AtLargeDistrict);
        }

        [Fact]
        public void RepresentativeHasPartyLoyaltyRatio()
        {
            Assert.NotNull(Fixture.Representative.PartyLoyaltyRatio);
        }

        [Fact]
        public void RepresentativeHasMissedVotesRatio()
        {
            Assert.NotNull(Fixture.Representative.MissedVotesRatio);
        }
        #endregion

        #region Senator Tests
        [Fact]
        public void SenatorArentNull()
        {
            Assert.NotNull(Fixture.Senator);
        }

        [Fact]
        public void SenatorHasFirstName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.FirstName));
        }

        [Fact]
        public void SenatorHasLastName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.LastName));
        }

        [Fact]
        public void SenatorHasFullName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.FullName));
        }

        [Fact]
        public void SenatorHasAnID()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.ID));
        }

        [Fact]
        public void SenatorHasAGender()
        {
            Assert.NotNull(Fixture.Senator.Gender);
        }

        [Fact]
        public void SenatorHasAHomeState()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.State));
        }

        [Fact]
        public void SenatorHasAParty()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.Party));
        }

        [Fact]
        public void SenatorHasABirthDate()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.BirthDate.ToString()));
        }

        [Fact]
        public void SenatorHasANextElection()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.NextElection.ToString()));
        }

        [Fact]
        public void SenatorHasASenateClass()
        {
            Assert.NotNull(Fixture.Senator.Class);
            Assert.False(Fixture.Senator.Class == 0);
        }

        [Fact]
        public void SenatorInOfficeHasAStateRank()
        {
            if (Fixture.Senator.InOffice)
                Assert.False(string.IsNullOrEmpty(Fixture.Senator.Rank));
        }

        [Fact]
        public void SenatorHasPartyLoyaltyRatio()
        {
            Assert.NotNull(Fixture.Senator.PartyLoyaltyRatio);
        }

        [Fact]
        public void SenatorHasMissedVotesRatio()
        {
            Assert.NotNull(Fixture.Senator.MissedVotesRatio);
        }
        #endregion
    }
}