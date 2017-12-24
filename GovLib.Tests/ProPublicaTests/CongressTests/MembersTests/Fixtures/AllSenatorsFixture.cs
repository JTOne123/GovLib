using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class AllSenatorsFixture : CongressFixture
    {
        public Senator[] AllSenators { get; }

        public AllSenatorsFixture()
        {
            AllSenators = Congress.Members.GetAllSenators(115);
        }
    }
}