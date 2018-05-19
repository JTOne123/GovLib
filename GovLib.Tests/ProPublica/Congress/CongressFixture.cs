using System;

namespace GovLib.Tests.ProPublica.Congress
{
    public class CongressFixture
    {
        public string ApiKey { get; }
        public GovLib.ProPublica.Congress Congress { get; }

        public CongressFixture()
        {
            ApiKey = Environment.GetEnvironmentVariable("PROPUBLICA_API_KEY");
            Congress = new GovLib.ProPublica.Congress(ApiKey, testClient: true);
        }
    }
}
