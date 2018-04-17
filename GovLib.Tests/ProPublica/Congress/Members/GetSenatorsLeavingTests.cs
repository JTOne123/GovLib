using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("ProPublica Test Collection")]
    public class GetSenatorsLeavingTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<SenatorSummary> Senators { get; }

        public GetSenatorsLeavingTests(CongressFixture fixture)
        {
            Senators = fixture.Congress.Members.GetSenatorsLeavingOffice(115);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Senators);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Senators);
        }

        [Fact]
        public void SenatorCardsAreNotNull()
        {
            foreach (var senatorCard in Senators)
                Assert.NotNull(senatorCard);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var senatorCard in Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var senatorCard in Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var senatorCard in Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var senatorCard in Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var senatorCard in Senators)
                Assert.NotNull(senatorCard.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            foreach (var senatorCard in Senators)
                Assert.False(string.IsNullOrEmpty(senatorCard.Party));
        }
    }
}