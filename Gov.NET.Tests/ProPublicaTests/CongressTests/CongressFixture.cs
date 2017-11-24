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
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            ApiKey = Environment.GetEnvironmentVariable("PROPUBLICA_API_KEY");
            Congress = new Congress(ApiKey);
        }
    }
}