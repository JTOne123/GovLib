using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("ProPublica Test Collection")]
    public class GetAllRepresentativesTests : IClassFixture<CongressFixture>
    {
        public Representative[] AllRepresentatives { get; }

        public GetAllRepresentativesTests(CongressFixture fixture)
        {
            AllRepresentatives = fixture.Congress.Members.GetAllRepresentatives();
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(AllRepresentatives);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(AllRepresentatives);
        }

        [Fact]
        public void AllRepresentativesArentNull()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative);
        }

        [Fact]
        public void AllRepresentativesHaveFirstName()
        {
            foreach (var representative in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(representative.FirstName));
        }

        [Fact]
        public void AllRepresentativesHaveLastName()
        {
            foreach (var representative in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(representative.LastName));
        }

        [Fact]
        public void AllRepresentativesHaveFullName()
        {
            foreach (var representative in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(representative.FullName));
        }

        [Fact]
        public void AllRepresentativesHaveAnID()
        {
            foreach (var representative in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(representative.CongressID));
        }

        [Fact]
        public void AllRepresentativesHaveAGender()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.Gender);
        }

        [Fact]
        public void AllRepresentativesHaveAHomeState()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.State);
        }

        [Fact]
        public void AllRepresentativesHaveAParty()
        {
            foreach (var representative in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(representative.Party));
        }

        [Fact]
        public void AllRepresentativesHaveABirthDate()
        {
            foreach (var representative in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(representative.BirthDate.ToString()));
        }

        [Fact]
        public void AllRepresentativesInOfficeHaveADistrict()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.District);
        }

        [Fact]
        public void AllRepresentativesInOfficeHaveAnAtLargeBool()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.AtLargeDistrict);
        }

        [Fact]
        public void AllRepresentativesHavePartyLoyaltyRatio()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.PartyLoyaltyRatio);
        }

        [Fact]
        public void AllRepresentativesHaveMissedVotesRatio()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.MissedVotesRatio);
        }

        [Fact]
        public void AllRepresentativesHaveTotalVotesCast()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.VotesCast);
        }

        [Fact]
        public void AllRepresentativesHaveTotalVotesMissed()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.VotesMissed);
        }

        [Fact]
        public void AllRepresentativesHaveTotalVotesPresent()
        {
            foreach (var representative in AllRepresentatives)
                Assert.NotNull(representative.VotesPresent);
        }
    }
}