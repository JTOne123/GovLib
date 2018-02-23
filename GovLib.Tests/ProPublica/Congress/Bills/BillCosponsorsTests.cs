using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("MainTestCollection")]
    public class BillCosponsorsTests : IClassFixture<CongressFixture>
    {
        public Politician[] BillCosponsors { get; }

        public BillCosponsorsTests(CongressFixture fixture)
        {
            BillCosponsors = fixture.Congress.Bills.GetBillCosponsors(115, "sres413");
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(BillCosponsors);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(BillCosponsors);
        }

        [Fact]
        public void AllRepresentativesArentNull()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.NotNull(congressMember);
        }

        [Fact]
        public void AllRepresentativesHaveFirstName()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.False(string.IsNullOrEmpty(congressMember.FirstName));
        }

        [Fact]
        public void AllRepresentativesHaveLastName()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.False(string.IsNullOrEmpty(congressMember.LastName));
        }

        [Fact]
        public void AllRepresentativesHaveFullName()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.False(string.IsNullOrEmpty(congressMember.FullName));
        }

        [Fact]
        public void AllRepresentativesHaveAnID()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.False(string.IsNullOrEmpty(congressMember.CongressID));
        }

        [Fact]
        public void AllRepresentativesHaveAGender()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.NotNull(congressMember.Gender);
        }

        [Fact]
        public void AllRepresentativesHaveAHomeState()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.NotNull(congressMember.State);
        }

        [Fact]
        public void AllRepresentativesHaveAParty()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.False(string.IsNullOrEmpty(congressMember.Party));
        }

        [Fact]
        public void AllRepresentativesHaveABirthDate()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.False(string.IsNullOrEmpty(congressMember.BirthDate.ToString()));
        }

        [Fact]
        public void AllRepresentativesHavePartyLoyaltyRatio()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.NotNull(congressMember.PartyLoyaltyRatio);
        }

        [Fact]
        public void AllRepresentativesHaveMissedVotesRatio()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.NotNull(congressMember.MissedVotesRatio);
        }

        [Fact]
        public void AllRepresentativesHaveTotalVotesCast()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.NotNull(congressMember.VotesCast);
        }

        [Fact]
        public void AllRepresentativesHaveTotalVotesMissed()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.NotNull(congressMember.VotesMissed);
        }

        [Fact]
        public void AllRepresentativesHaveTotalVotesPresent()
        {
            foreach (var congressMember in BillCosponsors)
                Assert.NotNull(congressMember.VotesPresent);
        }
    }
}