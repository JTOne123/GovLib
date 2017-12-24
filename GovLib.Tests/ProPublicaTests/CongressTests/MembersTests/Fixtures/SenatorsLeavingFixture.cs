using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class SenatorsLeavingFixture : CongressFixture
    {
        public SenatorSummary[] SenatorCards { get; }

        public SenatorsLeavingFixture()
        {
            SenatorCards = Congress.Members.GetSenatorsLeavingOffice(115);
        }
    }
}