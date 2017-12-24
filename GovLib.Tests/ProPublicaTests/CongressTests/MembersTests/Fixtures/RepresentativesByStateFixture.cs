using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;


namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class RepresentativesByStateFixture : CongressFixture
    {
        public RepresentativeSummary[] RepresentativeCards { get; }

        public RepresentativesByStateFixture()
        {
            RepresentativeCards = Congress.Members.GetRepresentaivesByState(State.California);
        }
    }
}