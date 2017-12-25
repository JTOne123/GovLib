using System.Threading;
using GovLib.Contracts;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class NewMembersFixture : CongressFixture
    {
        public Politician[] NewMembers { get; }

        public NewMembersFixture()
        {
            NewMembers = Congress.MembersApi.GetNewMembers();
            System.Console.WriteLine();
        }
    }
}