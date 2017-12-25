using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class MemberByIDFixture : CongressFixture
    {
        public Senator Senator { get; }
        public Representative Representative { get; }

        public MemberByIDFixture()
        {
            Senator = Congress.MembersApi.GetMemberByID("S000033") as Senator;
            Representative = Congress.MembersApi.GetMemberByID("R000570") as Representative;
        }
    }
}