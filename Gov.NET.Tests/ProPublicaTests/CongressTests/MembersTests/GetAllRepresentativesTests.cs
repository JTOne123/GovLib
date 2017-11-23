using System;
using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;
using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class GetAllRepresentativesTests
    {
        public string ApiKey { get; }
        public Congress Congress { get; }
        public Representative[] AllRepresentatives { get; }

        public GetAllRepresentativesTests()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            ApiKey = Environment.GetEnvironmentVariable("PROPUBLICA_KEY");
            Congress = new Congress(ApiKey);
            AllRepresentatives = Congress.Members.GetAllRepresentatives(115);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(AllRepresentatives);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(AllRepresentatives);
        }

        [Fact]
        public void AllRepresentativesArentNull()
        {
            foreach (var senator in AllRepresentatives)
                Assert.NotNull(senator);
        }

        [Fact]
        public void AllRepresentativesHaveFirstName()
        {
            foreach (var senator in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.FirstName));
        }

        [Fact]
        public void AllRepresentativesHaveLastName()
        {
            foreach (var senator in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.LastName));
        }

        [Fact]
        public void AllRepresentativesHaveFullName()
        {
            foreach (var senator in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.FullName));
        }

        [Fact]
        public void AllRepresentativesHaveAnID()
        {
            foreach (var senator in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.ID));
        }

        [Fact]
        public void AllRepresentativesHaveAHomeState()
        {
            foreach (var senator in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.State));
        }

        [Fact]
        public void AllRepresentativesHaveABirthDate()
        {
            foreach (var senator in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.BirthDate.ToString()));
        }

        [Fact]
        public void AllRepresentativesHaveANextElection()
        {
            foreach (var senator in AllRepresentatives)
                Assert.False(string.IsNullOrEmpty(senator.NextElection.ToString()));
        }
    }
}