using System;
using System.Threading;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests
{
    public abstract class CongressFixture
    {
        public string ApiKey { get; }
        public Congress Congress { get; }

        public CongressFixture()
        {
            ApiKey = Environment.GetEnvironmentVariable("PROPUBLICA_API_KEY");
            Congress = new Congress(ApiKey);
        }
    }
}