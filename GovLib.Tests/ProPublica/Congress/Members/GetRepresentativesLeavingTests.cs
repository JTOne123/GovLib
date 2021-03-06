using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("ProPublica Test Collection")]
    public class GetRepresentativesLeavingTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<RepresentativeSummary> RepsLeaving { get; }

        public GetRepresentativesLeavingTests(CongressFixture fixture)
        {
            RepsLeaving = fixture.Congress.Members.GetRepresentativesLeavingOffice(115);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(RepsLeaving);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(RepsLeaving);
        }

        [Fact]
        public void RepresentativeCardsAreNotNull()
        {
            foreach (var representativeCard in RepsLeaving)
                Assert.NotNull(representativeCard);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var representativeCard in RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var representativeCard in RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var representativeCard in RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var representativeCard in RepsLeaving)
                Assert.False(string.IsNullOrEmpty(representativeCard.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var representativeCard in RepsLeaving)
                Assert.NotNull(representativeCard.State);
        }
    }
}