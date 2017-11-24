using System.Threading;
using Gov.NET.Models;
using Gov.NET.Common.Models.Cards;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class SenatorsLeavingFixture : CongressFixture
    {
        public SenatorCard[] SenatorCards { get; }

        public SenatorsLeavingFixture()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            SenatorCards = Congress.Members.GetSenatorsLeavingOffice(115);
        }
    }
}