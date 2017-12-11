using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;


namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
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