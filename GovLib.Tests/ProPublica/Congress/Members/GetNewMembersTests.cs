using System.Collections.Generic;
using GovLib.ProPublica;
using Xunit;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    [Collection("ProPublica Test Collection")]
    public class GetNewMembersTests : IClassFixture<CongressFixture>
    {
        public IEnumerable<PoliticianSummary> NewMembers { get; }

        public GetNewMembersTests(CongressFixture fixture)
        {
            NewMembers = fixture.Congress.Members.GetNewMembers();
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(NewMembers);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(NewMembers);
        }

        [Fact]
        public void MemberCardsAreNotNull()
        {
            foreach (var member in NewMembers)
                Assert.NotNull(member);
        }

        [Fact]
        public void MemberCardsHaveFirstName()
        {
            foreach (var member in NewMembers)
                Assert.False(string.IsNullOrEmpty(member.FirstName));
        }

        [Fact]
        public void MemberCardsHaveLastName()
        {
            foreach (var member in NewMembers)
                Assert.False(string.IsNullOrEmpty(member.LastName));
        }

        [Fact]
        public void MemberCardsHaveFullName()
        {
            foreach (var member in NewMembers)
                Assert.False(string.IsNullOrEmpty(member.FullName));
        }

        [Fact]
        public void MemberCardsHaveAnID()
        {
            foreach (var member in NewMembers)
                Assert.False(string.IsNullOrEmpty(member.CongressID));
        }

        [Fact]
        public void MemberCardsHaveAHomeState()
        {
            foreach (var member in NewMembers)
                Assert.NotNull(member.State);
        }
    }
}