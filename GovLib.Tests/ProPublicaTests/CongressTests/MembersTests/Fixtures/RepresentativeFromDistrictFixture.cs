using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class RepresentativeFromDistrictFixture : CongressFixture
    {
        public Representative DistrictRep { get; }

        public RepresentativeFromDistrictFixture()
        {
            DistrictRep = Congress.MembersApi.GetRepresentiveFromDistrict(State.Oregon, 3);
        }
    }
}