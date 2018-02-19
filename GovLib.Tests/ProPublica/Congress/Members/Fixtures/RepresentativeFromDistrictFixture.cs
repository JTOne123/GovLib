using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class RepresentativeFromDistrictFixture : CongressFixture
    {
        public Representative DistrictRep { get; }

        public RepresentativeFromDistrictFixture()
        {
            DistrictRep = Congress.Members.GetRepresentiveFromDistrict(State.Oregon, 3);
        }
    }
}