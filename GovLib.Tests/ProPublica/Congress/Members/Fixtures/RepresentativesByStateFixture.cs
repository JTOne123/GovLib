using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;


namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class RepresentativesByStateFixture : CongressFixture
    {
        public Representative[] StateReps { get; }

        public RepresentativesByStateFixture()
        {
            StateReps = Congress.Members.GetRepresentaivesByState(State.California);
        }
    }
}