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
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            PoliticianCards = Congress.Members.GetNewMembers();
            System.Console.WriteLine();
        }
    }
}