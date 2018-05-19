using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Votes
{
    public class HouseRollCallVotesTests : IClassFixture<CongressFixture>
    {
        public VoteRollCall VoteRollCall { get; }

        public HouseRollCallVotesTests(CongressFixture fixture)
        {
            VoteRollCall = fixture.Congress.Votes.GetRollCallVote(Chamber.House, 114, 1, 17);
        }

        [Fact]
        public void VoteRollCallIsntNull()
        {
            Assert.NotNull(VoteRollCall);
        }

        [Fact]
        public void VoteRollCallIsFromTheHouse()
        {
            Assert.True(VoteRollCall.Chamber.Equals(Chamber.House));
        }

        [Fact]
        public void VoteRollCallHasAValidSession()
        {
            // Sessions can only be 1 or 2
            Assert.True(VoteRollCall.Session > 0 && VoteRollCall.Session < 3);
        }

        [Fact]
        public void VoteRollCallPositionsAreValid()
        {
            foreach (var position in VoteRollCall.Positions)
            {
                Assert.NotNull(position.CongressID);
                Assert.NotNull(position.FullName);
                Assert.NotNull(position.Vote);
            }
        }
    }
}