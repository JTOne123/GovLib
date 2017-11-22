using System;
using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;
using Xunit;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests
{
    public class GetAllSenatorsTests
    {
        public Congress Congress { get; } = new Congress(Environment.GetEnvironmentVariable("PROPUBLICA_KEY"));
        public Senator[] AllSenators { get; }

        public GetAllSenatorsTests()
        {
            Thread.Sleep(60);
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
        public void CollectionObjectsArentNull()
        {
            Assert.NotNull(AllSenators[5]);
        }

        [Fact]
        public void CollectionObjectHasFirstName()
        {
            Assert.False(string.IsNullOrEmpty(AllSenators[5].FirstName));
        }

        [Fact]
        public void CollectionObjectHasLastName()
        {
            Assert.False(string.IsNullOrEmpty(AllSenators[5].LastName));
        }

        [Fact]
        public void CollectionObjectHasFullName()
        {
            Assert.False(string.IsNullOrEmpty(AllSenators[5].FullName));
        }

        [Fact]
        public void CollectionObjectsAreUnique()
        {
            Assert.NotEqual(AllSenators[1].LastName, AllSenators[0].LastName);
        }
    }
}