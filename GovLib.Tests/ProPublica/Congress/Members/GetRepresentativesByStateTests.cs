using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("MainTestCollection")]
    public class GetRepresentativesByStateTests : IClassFixture<CongressFixture>
    {
        public RepresentativeSummary[] StateReps { get; }

        public GetRepresentativesByStateTests(CongressFixture fixture)
        {
            StateReps = fixture.Congress.Members.GetRepresentativesByState(State.Texas);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(StateReps);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(StateReps);
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            foreach (var member in StateReps)
                Assert.NotNull(member);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var member in StateReps)
                Assert.False(string.IsNullOrEmpty(member.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var member in StateReps)
                Assert.False(string.IsNullOrEmpty(member.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var member in StateReps)
                Assert.False(string.IsNullOrEmpty(member.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var member in StateReps)
                Assert.False(string.IsNullOrEmpty(member.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var member in StateReps)
                Assert.NotNull(member.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            foreach (var member in StateReps)
                Assert.False(string.IsNullOrEmpty(member.Party));
        }
    }
}