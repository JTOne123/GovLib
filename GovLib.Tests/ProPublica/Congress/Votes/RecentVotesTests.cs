using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Votes
{
    [Collection("ProPublica Test Collection")]
    public class RecentVotesTests : IClassFixture<CongressFixture>
    {
        private readonly CongressFixture _fixture;

        public RecentVotesTests(CongressFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void GetRecentSenateVotes()
        {
            var votes = _fixture.Congress.Votes.GetRecentVotes(Chamber.Senate);

            Assert.NotNull(votes);
            Assert.NotEmpty(votes);
        }

        [Fact]
        public void GetRecentHouseVotes()
        {
            var votes = _fixture.Congress.Votes.GetRecentVotes(Chamber.House);

            Assert.NotNull(votes);
            Assert.NotEmpty(votes);
        }
    }
}