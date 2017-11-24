using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
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