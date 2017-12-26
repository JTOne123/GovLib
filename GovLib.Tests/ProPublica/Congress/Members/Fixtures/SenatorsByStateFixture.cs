using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class SenatorsByStateFixture : CongressFixture
    {
        public Senator[] StateSenators { get; }

        public SenatorsByStateFixture()
        {
            StateSenators = Congress.Members.GetSenatorsByState(State.Georgia);
        }
    }
}