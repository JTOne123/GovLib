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
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            RepresentativeCards = Congress.Members.GetRepresentativesLeavingOffice(115);
        }
    }
}