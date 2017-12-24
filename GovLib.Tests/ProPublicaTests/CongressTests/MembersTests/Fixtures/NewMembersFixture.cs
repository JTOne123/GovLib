using System.Threading;
using GovLib.Models;
using GovLib.ProPublica;

namespace GovLib.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class NewMembersFixture : CongressFixture
    {
        public PoliticianSummary[] PoliticianCards { get; }

        public NewMembersFixture()
        {
            PoliticianCards = Congress.Members.GetNewMembers();
            System.Console.WriteLine();
        }
    }
}