using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class AllReprentativesFixture : CongressFixture
    {
        public Representative[] AllRepresentatives { get; }

        public AllReprentativesFixture()
        {
            AllRepresentatives = Congress.Members.GetAllRepresentatives(115);
        }
    }
}