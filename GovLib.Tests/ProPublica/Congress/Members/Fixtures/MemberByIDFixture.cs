using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublica.Congress.Members
{
    public class MemberByIDFixture : CongressFixture
    {
        public Senator Senator { get; }
        public Representative Representative { get; }

        public MemberByIDFixture()
        {
            Senator = Congress.Members.GetMemberByID("S000033") as Senator;
            Representative = Congress.Members.GetMemberByID("R000570") as Representative;
        }
    }
}