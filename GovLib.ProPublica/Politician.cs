using System;
using GovLib.Contracts;

namespace GovLib.ProPublica
{
    /// <summary>Abstract implementation for a generic politician.</summary>
    public abstract class Politician : ICongressMember
    {
        #pragma warning disable CS1591

        public string CongressID { get; internal set; }
        public string FirstName { get; internal set; }
        public string MiddleName { get; internal set; }
        public string LastName { get; internal set; }
        public string FullName =>
            string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
        public string Party { get; internal set; }
        public State State { get; internal set; }
        public DateTime BirthDate { get; internal set; }
        public int Age => new DateTime(DateTime.UtcNow.Subtract(BirthDate).Ticks).Year - 1;
        public Gender Gender { get; internal set; }
        public string Url { get; internal set; }
        public string Twitter { get; internal set; }
        public string Facebook { get; internal set; }
        public string Youtube { get; internal set; }
        public int Seniority { get; internal set; }
        public string Office { get; internal set; }
        public string Phone { get; internal set; }
        public string Fax { get; internal set; }
        public bool InOffice { get; internal set; }
        public int NextElection { get; internal set; }
        public string OcdID { get; internal set; }
        public int VotesCast { get; internal set; }
        public int VotesMissed { get; internal set; }
        public int VotesPresent { get; internal set; }
        public double MissedVotesRatio { get; internal set; }
        public double PartyLoyaltyRatio { get; internal set; }
    }
}
