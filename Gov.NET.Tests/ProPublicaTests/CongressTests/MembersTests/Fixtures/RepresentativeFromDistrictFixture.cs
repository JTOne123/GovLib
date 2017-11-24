using System.Threading;
using Gov.NET.Models;
using Gov.NET.Common.Models.Cards;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class RepresentativeFromDistrictFixture : CongressFixture
    {
        public RepresentativeCard RepresentativeCard { get; }

        public RepresentativeFromDistrictFixture()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            RepresentativeCard = Congress.Members.GetRepresentiveFromDistrict("WA", 3);
        }
    }
}