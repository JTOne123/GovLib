using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
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