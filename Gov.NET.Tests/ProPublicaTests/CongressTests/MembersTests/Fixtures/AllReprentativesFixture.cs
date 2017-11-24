using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class AllReprentativesFixture : CongressFixture
    {
        public Representative[] AllRepresentatives { get; }

        public AllReprentativesFixture()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            AllRepresentatives = Congress.Members.GetAllRepresentatives(115);
        }
    }
}