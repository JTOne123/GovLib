using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class SenatorsLeavingFixture : CongressFixture
    {
        public Senator[] Senators { get; }

        public SenatorsLeavingFixture()
        {
            Senators = Congress.Members.GetSenatorsLeavingOffice(115);
        }
    }
}