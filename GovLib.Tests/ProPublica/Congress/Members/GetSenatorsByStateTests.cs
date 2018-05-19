using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("ProPublica Test Collection")]
    public class GetSenatorsByStateTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<SenatorSummary> StateSenators { get; }

        public GetSenatorsByStateTests(CongressFixture fixture)
        {
            StateSenators = fixture.Congress.Members.GetSenatorsByState(State.Colorado);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(StateSenators);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(StateSenators);
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            foreach (var member in StateSenators)
                Assert.NotNull(member);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var member in StateSenators)
                Assert.False(string.IsNullOrEmpty(member.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var member in StateSenators)
                Assert.False(string.IsNullOrEmpty(member.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var member in StateSenators)
                Assert.False(string.IsNullOrEmpty(member.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var member in StateSenators)
                Assert.False(string.IsNullOrEmpty(member.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var member in StateSenators)
                Assert.NotNull(member.State);
        }
    }
}