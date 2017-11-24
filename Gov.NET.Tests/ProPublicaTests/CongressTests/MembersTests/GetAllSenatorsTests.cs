using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class GetAllSenatorsTests : IClassFixture<AllSenatorsFixture>
    {
        public AllSenatorsFixture Fixture { get; }

        public GetAllSenatorsTests(AllSenatorsFixture fixture)
        {
            this.Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.AllSenators);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.AllSenators);
        }

        [Fact]
        public void AllSenatorsArentNull()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.NotNull(senator);
        }

        [Fact]
        public void AllSenatorsHaveFirstName()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.FirstName));
        }

        [Fact]
        public void AllSenatorsHaveLastName()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.LastName));
        }

        [Fact]
        public void AllSenatorsHaveFullName()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.FullName));
        }

        [Fact]
        public void AllSenatorsHaveAnID()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.ID));
        }

        [Fact]
        public void AllSenatorsHaveAHomeState()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.State));
        }

        [Fact]
        public void AllSenatorsHaveABirthDate()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.BirthDate.ToString()));
        }

        [Fact]
        public void AllSenatorsHaveANextElection()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.NextElection.ToString()));
        }

        [Fact]
        public void AllSenatorsHaveASenateClass()
        {
            foreach (var senator in Fixture.AllSenators)
            {
                Assert.NotNull(senator.Class);
                Assert.False(senator.Class == 0);
            }
        }

        [Fact]
        public void AllSenatorsInOfficeHaveAStateRank()
        {
            foreach (var senator in Fixture.AllSenators)
            {
                if (senator.InOffice)
                    Assert.False(string.IsNullOrEmpty(senator.Rank));
            }
        }

        [Fact]
        public void AllSenatorsHavePartyLoyaltyRatio()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.NotNull(senator.PartyLoyaltyRatio);
        }

        [Fact]
        public void AllSenatorsHaveMissedVotesRatio()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.NotNull(senator.MissedVotesRatio);
        }

        [Fact]
        public void AllSenatorsHaveTotalVotesCast()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.NotNull(senator.VotesCast);
        }

        [Fact]
        public void AllSenatorsHaveTotalVotesMissed()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.NotNull(senator.VotesMissed);
        }

        [Fact]
        public void AllSenatorsHaveTotalVotesPresent()
        {
            foreach (var senator in Fixture.AllSenators)
                Assert.NotNull(senator.VotesPresent);
        }
    }
}
