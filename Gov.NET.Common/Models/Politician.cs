using System;
using System.Collections.Generic;
using Gov.NET.Common.Models.Contracts;
using static Gov.NET.Models.Enums;

namespace Gov.NET.Models
{
    public class Politician : IPolitician
    {
        
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => GetFullName();
        public string Party { get; set; }
        public State State { get; set; }
        public DateTime BirthDate { get; set; }
        public int? Age => DateTime.Now.Year - BirthDate.Year;
        public Enums.Gender Gender { get; set; }
        public string Url { get; set; }
        public string Twitter { get; set; }
        public string Facebook { get; set; }
        public string Youtube { get; set; }
        public int? Seniority { get; set; }
        public string Office { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public bool InOffice { get; set; }
        public int? NextElection { get; set; }
        public string OcdID { get; set; }
        public int? VotesCast { get; set; }
        public int? VotesMissed { get; set; }
        public int? VotesPresent { get; set; }
        public double? MissedVotesRatio { get; set; }
        public double? PartyLoyaltyRatio { get; set; }
        
        private string GetFullName()
        {
            if (string.IsNullOrEmpty(MiddleName)) return $"{FirstName} {LastName}";
            else return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}
