using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class GetAllRepresentativesTests : IClassFixture<AllReprentativesFixture>
    {
        public AllReprentativesFixture Fixture { get; }

        public GetAllRepresentativesTests(AllReprentativesFixture fixture)
        {
            this.Fixture = fixture;
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(Fixture.AllRepresentatives);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(Fixture.AllRepresentatives);
        }

        [Fact]
        public void AllRepresentativesArentNull()
        {
            foreach (var senator in Fixture.AllRepresentatives)
                Assert.NotNull(senator);
        }

        [Fact]
        public void AllRepresentativesHaveFirstName()
        {
            foreach (var senator in Fixture.AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.FirstName));
        }

        [Fact]
        public void AllRepresentativesHaveLastName()
        {
            foreach (var senator in Fixture.AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.LastName));
        }

        [Fact]
        public void AllRepresentativesHaveFullName()
        {
            foreach (var senator in Fixture.AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.FullName));
        }

        [Fact]
        public void AllRepresentativesHaveAnID()
        {
            foreach (var senator in Fixture.AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.ID));
        }

        [Fact]
        public void AllRepresentativesHaveAHomeState()
        {
            foreach (var senator in Fixture.AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.State));
        }

        [Fact]
        public void AllRepresentativesHaveABirthDate()
        {
            foreach (var senator in Fixture.AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.BirthDate.ToString()));
        }

        [Fact]
        public void AllRepresentativesHaveANextElection()
        {
            foreach (var senator in Fixture.AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.NextElection.ToString()));
        }
    }
}