using System;

namespace GovLib.Models
{
    /// <summary>Full implementation for a generic politician.</summary>
    public class Politician : PoliticianSummary
    {
        #pragma warning disable CS1591

        public DateTime BirthDate { get; set; }
        public int Age => DateTime.Now.Year - BirthDate.Year;
        public Gender Gender { get; set; }
        public string Url { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public int Seniority { get; set; }
        public string Office { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool InOffice { get; set; }
        public int NextElection { get; set; }
        public string OcdID { get; set; }
        public int VotesCast { get; set; }
        public int VotesMissed { get; set; }
        public int VotesPresent { get; set; }
        public double MissedVotesRatio { get; set; }
        public double PartyLoyaltyRatio { get; set; }
        
        #pragma warning restore CS1591
    }
}
