using System.Threading;
using Gov.NET.Models;
using Gov.NET.ProPublica;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
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