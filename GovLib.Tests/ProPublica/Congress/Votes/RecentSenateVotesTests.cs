using System.Collections.Generic;
using System.Linq;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Votes
{
    [Collection("ProPublica Test Collection")]
    public class RecentSenateVotesTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<Vote> RecentSenateVotes { get; }

        public RecentSenateVotesTests(CongressFixture fixture)
        {
            RecentSenateVotes = fixture.Congress.Votes.GetRecentVotes(Chamber.Senate);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(RecentSenateVotes);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(RecentSenateVotes);
        }

        [Fact]
        public void VotesArentNull()
        {
            foreach (var vote in RecentSenateVotes)
            {
                Assert.NotNull(vote);
            }
        }

        [Fact]
        public void VotesAreFromTheSenate()
        {
            foreach (var vote in RecentSenateVotes)
            {
                Assert.True(vote.Chamber.Equals(Chamber.Senate));
            }
        }

        [Fact]
        public void VotesHaveAppropriateSubType()
        {
            foreach (var vote in RecentSenateVotes)
            {
                if (vote is NominationVote)
                {
                    var nomVote = vote as NominationVote;
                    Assert.False(string.IsNullOrEmpty(nomVote.NominationID));
                    Assert.False(string.IsNullOrEmpty(nomVote.Number));
                    Assert.False(string.IsNullOrEmpty(nomVote.Name));
                    Assert.False(string.IsNullOrEmpty(nomVote.Agency));
                }
                else if (vote is AmendmentVote)
                {
                    var amnVote = vote as AmendmentVote;
                    Assert.False(string.IsNullOrEmpty(amnVote.AmendmentID));
                }
                else
                {
                    var billVote = vote as BillVote;
                    Assert.False(string.IsNullOrEmpty(billVote.BillID));
                    Assert.False(string.IsNullOrEmpty(billVote.Number));
                    Assert.False(string.IsNullOrEmpty(billVote.SponsorID));
                }
            }
        }

        [Fact]
        public void VotesHaveATitle()
        {
            foreach (var vote in RecentSenateVotes)
            {
                Assert.False(string.IsNullOrEmpty(vote.Title));
            }
        }

        [Fact]
        public void VotesHaveABillDescription()
        {
            foreach (var vote in RecentSenateVotes)
            {
                Assert.False(string.IsNullOrEmpty(vote.Description));
            }
        }

        [Fact]
        public void VotesHaveAValidSession()
        {
            foreach (var vote in RecentSenateVotes)
            {
                // Sessions can only be 1 or 2
                Assert.True(vote.Session > 0 && vote.Session < 3);
            }
        }
    }
}