using GovLib.ProPublica;


namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class RepresentativesByStateFixture : CongressFixture
    {
        public Representative[] StateReps { get; }

        public RepresentativesByStateFixture()
        {
            StateReps = Congress.Members.GetRepresentativesByState(State.California);
        }
    }
}