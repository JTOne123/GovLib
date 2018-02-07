using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class AllReprentativesFixture : CongressFixture
    {
        public Representative[] AllRepresentatives { get; }

        public AllReprentativesFixture()
        {
            AllRepresentatives = Congress.Members.GetAllRepresentatives(115);
        }
    }
}