using System.Threading;
using Gov.NET.Models;
using Gov.NET.Common.Models.Cards;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class SenatorsByStateFixture : CongressFixture
    {
        public SenatorCard[] SenatorCards { get; }

        public SenatorsByStateFixture()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            SenatorCards = Congress.Members.GetSenatorsByState("CO");
        }
    }
}