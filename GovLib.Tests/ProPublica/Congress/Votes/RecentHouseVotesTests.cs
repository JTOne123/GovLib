using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Votes
{
    public class RecentHouseVotesTests : IClassFixture<CongressFixture>
    {
        
        public IEnumerable<Vote> RecentHouseVotes { get; }

        public RecentHouseVotesTests(CongressFixture fixture)
        {
            RecentHouseVotes = fixture.Congress.Votes.GetRecentVotes(Chamber.House);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(RecentHouseVotes);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(RecentHouseVotes);
        }

        [Fact]
        public void VotesArentNull()
        {
            foreach (var vote in RecentHouseVotes)
            {
                Assert.NotNull(vote);
            }
        }

        [Fact]
        public void VotesAreFromTheHouse()
        {
            foreach (var vote in RecentHouseVotes)
            {
                Assert.True(vote.Chamber.Equals(Chamber.House));
            }
        }

        [Fact]
        public void VotesHaveAppropriateSubType()
        {
            foreach (var vote in RecentHouseVotes)
            {
                if (vote is AmendmentVote)
                {
                    var amendmentVote = vote as AmendmentVote;
                    Assert.False(string.IsNullOrEmpty(amendmentVote.AmendmentID));
                }
                else if (vote is JournalVote)
                {
                    var journalVote = vote as JournalVote;
                    Assert.False(string.IsNullOrEmpty(journalVote.BillID));
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
        public void VotesHaveAValidSession()
        {
            foreach (var vote in RecentHouseVotes)
            {
                // Sessions can only be 1 or 2
                Assert.True(vote.Session > 0 && vote.Session < 3);
            }
        }
    }
}