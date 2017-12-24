using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class RepresentativeFromDistrictFixture : CongressFixture
    {
        public RepresentativeSummary RepresentativeCard { get; }

        public RepresentativeFromDistrictFixture()
        {
            RepresentativeCard = Congress.Members.GetRepresentiveFromDistrict(State.Oregon, 3);
        }
    }
}