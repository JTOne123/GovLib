using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class MemberByIDFixture : CongressFixture
    {
        public Senator Senator { get; }
        public Representative Representative { get; }

        public MemberByIDFixture()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            Senator = (Senator) Congress.Members.GetMemberByID("S000033");
            // Sleep again before making an additional API call.
            Thread.Sleep(60);
            Representative = (Representative) Congress.Members.GetMemberByID("R000570");
        }
    }
}