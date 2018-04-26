using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Votes
{
    public class HouseRollCallVotesTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<Vote> HouseRollCallVotes { get; }

        public HouseRollCallVotesTests(CongressFixture fixture)
        {
            HouseRollCallVotes = fixture.Congress.Votes.GetRollCallVote(Chamber.House, 114, 1, 17);
        }

        [Fact(Skip = "Not Finished")]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(HouseRollCallVotes);
        }

        [Fact(Skip = "Not Finished")]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(HouseRollCallVotes);
        }

        [Fact(Skip = "Not Finished")]
        public void VotesArentNull()
        {
            foreach (var vote in HouseRollCallVotes)
            {
                Assert.NotNull(vote);
            }
        }

        [Fact(Skip = "Not Finished")]
        public void VotesAreFromTheHouse()
        {
            foreach (var vote in HouseRollCallVotes)
            {
                Assert.True(vote.Chamber.Equals(Chamber.House));
            }
        }

        [Fact(Skip = "Not Finished")]
        public void VotesHaveAppropriateSubType()
        {
            foreach (var vote in HouseRollCallVotes)
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

        [Fact(Skip = "Not Finished")]
        public void VotesHaveAValidSession()
        {
            foreach (var vote in HouseRollCallVotes)
            {
                // Sessions can only be 1 or 2
                Assert.True(vote.Session > 0 && vote.Session < 3);
            }
        }
    }
}