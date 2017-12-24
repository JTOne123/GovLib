using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
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