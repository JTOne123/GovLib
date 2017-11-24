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
        public void AllSenatorsArentNull()
        {
            Assert.NotNull(Fixture.Senator);
        }

        [Fact]
        public void AllSenatorsHaveFirstName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.FirstName));
        }

        [Fact]
        public void AllSenatorsHaveLastName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.LastName));
        }

        [Fact]
        public void AllSenatorsHaveFullName()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.FullName));
        }

        [Fact]
        public void AllSenatorsHaveAnID()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.ID));
        }

        [Fact]
        public void AllSenatorsHaveAGender()
        {
            Assert.NotNull(Fixture.Senator.Gender);
        }

        [Fact]
        public void AllSenatorsHaveAHomeState()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.State));
        }

        [Fact]
        public void AllSenatorsHaveABirthDate()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.BirthDate.ToString()));
        }

        [Fact]
        public void AllSenatorsHaveANextElection()
        {
            Assert.False(string.IsNullOrEmpty(Fixture.Senator.NextElection.ToString()));
        }

        [Fact]
        public void AllSenatorsHaveASenateClass()
        {
            Assert.NotNull(Fixture.Senator.Class);
            Assert.False(Fixture.Senator.Class == 0);
        }

        [Fact]
        public void AllSenatorsInOfficeHaveAStateRank()
        {
            if (Fixture.Senator.InOffice)
                Assert.False(string.IsNullOrEmpty(Fixture.Senator.Rank));
        }

        [Fact]
        public void AllSenatorsHavePartyLoyaltyRatio()
        {
            Assert.NotNull(Fixture.Senator.PartyLoyaltyRatio);
        }

        [Fact]
        public void AllSenatorsHaveMissedVotesRatio()
        {
            Assert.NotNull(Fixture.Senator.MissedVotesRatio);
        }
        #endregion
    }
}