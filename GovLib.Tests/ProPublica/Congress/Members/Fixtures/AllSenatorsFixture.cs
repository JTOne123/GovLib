using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class AllSenatorsFixture : CongressFixture
    {
        public Senator[] AllSenators { get; }

        public AllSenatorsFixture()
        {
            AllSenators = Congress.Members.GetAllSenators();
        }
    }
}