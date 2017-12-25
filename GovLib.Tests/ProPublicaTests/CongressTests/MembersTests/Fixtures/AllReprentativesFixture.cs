using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class AllReprentativesFixture : CongressFixture
    {
        public Representative[] AllRepresentatives { get; }

        public AllReprentativesFixture()
        {
            AllRepresentatives = Congress.MembersApi.GetAllRepresentatives(115);
        }
    }
}