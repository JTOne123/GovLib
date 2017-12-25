using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class SenatorsByStateFixture : CongressFixture
    {
        public Senator[] StateSenators { get; }

        public SenatorsByStateFixture()
        {
            StateSenators = Congress.MembersApi.GetSenatorsByState(State.Georgia);
        }
    }
}