using System;
using System.Threading;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests
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