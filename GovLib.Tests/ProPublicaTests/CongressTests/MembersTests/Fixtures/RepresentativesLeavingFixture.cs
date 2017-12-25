using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class RepresentativesLeavingFixture : CongressFixture
    {
        public Representative[] RepsLeaving { get; }

        public RepresentativesLeavingFixture()
        {
            RepsLeaving = Congress.MembersApi.GetRepresentativesLeavingOffice(115);
        }
    }
}