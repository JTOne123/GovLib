using System;
using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;
using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class GetAllSenatorsTests
    {
        public string ApiKey { get; private set; }
        public Congress Congress { get; private set; }
        public Senator[] AllSenators { get; private set; }

        public GetAllSenatorsTests()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            ApiKey = Environment.GetEnvironmentVariable("PROPUBLICA_KEY");
            Congress = new Congress(ApiKey);
            AllSenators = Congress.Members.GetAllSenators(115);
        }

        [Fact]
        public void CollectionIsNotNull()
        {
            Assert.NotNull(AllSenators);
        }

        [Fact]
        public void CollectionIsNotEmpty()
        {
            Assert.NotEmpty(AllSenators);
        }

        [Fact]
        public void AllSenatorsArentNull()
        {
            foreach (var senator in AllSenators)
                Assert.NotNull(senator);
        }

        [Fact]
        public void AllSenatorsHaveFirstName()
        {
            foreach (var senator in AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.FirstName));
        }

        [Fact]
        public void AllSenatorsHaveLastName()
        {
            foreach (var senator in AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.LastName));
        }

        [Fact]
        public void AllSenatorsHaveFullName()
        {
            foreach (var senator in AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.FullName));
        }

        [Fact]
        public void AllSenatorsHaveAnID()
        {
            foreach (var senator in AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.ID));
        }

        [Fact]
        public void AllSenatorsHaveAHomeState()
        {
            foreach (var senator in AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.State));
        }

        [Fact]
        public void AllSenatorsHaveABirthDate()
        {
            foreach (var senator in AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.BirthDate.ToString()));
        }

        [Fact]
        public void AllSenatorsHaveANextElection()
        {
            foreach (var senator in AllSenators)
                Assert.False(string.IsNullOrEmpty(senator.NextElection.ToString()));
        }
    }
}