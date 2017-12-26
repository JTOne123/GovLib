using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class GetRepresentativesLeavingTests : IClassFixture<RepresentativesLeavingFixture>
    {
        
        public RepresentativesLeavingFixture Fixture { get; }

        public GetRepresentativesLeavingTests(RepresentativesLeavingFixture fixture)
        {
            this.Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.RepsLeaving);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.RepsLeaving);
        }

        [Fact]
        public void RepresentativeCardsAreNotNull()
        {
            foreach (var representativeCard in Fixture.RepsLeaving)
                Assert.NotNull(representativeCard);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var representativeCard in Fixture.RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var representativeCard in Fixture.RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var representativeCard in Fixture.RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var representativeCard in Fixture.RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var representativeCard in Fixture.RepsLeaving)
                Assert.NotNull(representativeCard.State);
        }

        [Fact]
        public void MemberCardsHaveAParty()
        {
            foreach (var representativeCard in Fixture.RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.Party));
        }
    }
}