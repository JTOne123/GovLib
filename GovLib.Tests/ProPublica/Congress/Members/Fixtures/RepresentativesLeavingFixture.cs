using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class RepresentativesLeavingFixture : CongressFixture
    {
        public Representative[] RepsLeaving { get; }

        public RepresentativesLeavingFixture()
        {
            RepsLeaving = Congress.Members.GetRepresentativesLeavingOffice(115);
        }
    }
}