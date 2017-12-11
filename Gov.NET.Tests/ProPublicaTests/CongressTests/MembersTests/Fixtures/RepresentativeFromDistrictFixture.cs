using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
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