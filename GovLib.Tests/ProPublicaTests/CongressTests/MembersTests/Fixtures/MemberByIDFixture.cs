using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class MemberByIDFixture : CongressFixture
    {
        public Senator Senator { get; }
        public Representative Representative { get; }

        public MemberByIDFixture()
        {
            Senator = (Senator) Congress.Members.GetMemberByID("S000033");
            Representative = (Representative) Congress.Members.GetMemberByID("R000570");
        }
    }
}