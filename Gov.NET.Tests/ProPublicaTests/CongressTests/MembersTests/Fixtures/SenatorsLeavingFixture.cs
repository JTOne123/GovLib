using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
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