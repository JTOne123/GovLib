using System.Threading;
using Gov.NET.Models;
using Gov.NET.Models.Summaries;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class RepresentativeFromDistrictFixture : CongressFixture
    {
        public RepresentativeSummary RepresentativeCard { get; }

        public RepresentativeFromDistrictFixture()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            RepresentativeCard = Congress.Members.GetRepresentiveFromDistrict(State.Oregon, 3);
        }
    }
}