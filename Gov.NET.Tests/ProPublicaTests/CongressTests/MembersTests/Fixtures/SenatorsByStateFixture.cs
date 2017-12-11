using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class SenatorsByStateFixture : CongressFixture
    {
        public SenatorSummary[] SenatorCards { get; }

        public SenatorsByStateFixture()
        {
            SenatorCards = Congress.Members.GetSenatorsByState(State.Georgia);
        }
    }
}