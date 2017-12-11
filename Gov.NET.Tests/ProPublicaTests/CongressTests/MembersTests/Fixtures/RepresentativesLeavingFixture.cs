using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class RepresentativesLeavingFixture : CongressFixture
    {
        public RepresentativeSummary[] RepresentativeCards { get; }

        public RepresentativesLeavingFixture()
        {
            RepresentativeCards = Congress.Members.GetRepresentativesLeavingOffice(115);
        }
    }
}