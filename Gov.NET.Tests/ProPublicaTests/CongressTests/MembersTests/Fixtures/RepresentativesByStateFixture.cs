using System.Threading;
using Gov.NET.Models;
using Gov.NET.Models.Summaries;
using Gov.NET.ProPublica;
using System;

namespace Gov.NET.Tests.ProPublicaTests.CongressTests.MembersTests
{
    public class RepresentativesByStateFixture : CongressFixture
    {
        public RepresentativeSummary[] RepresentativeCards { get; }

        public RepresentativesByStateFixture()
        {
            // Sleep before making api call to limit request spam.
            Thread.Sleep(60);
            RepresentativeCards = Congress.Members.GetRepresentaivesByState("CO");
            Console.WriteLine();
        }
    }
}