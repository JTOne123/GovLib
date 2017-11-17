using System;
using System.Collections.Generic;

namespace Gov.NET.Models
{
    public abstract class Politician
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => GetFullName();
        public string Party { get; set; }
        public string State { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
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


        private string GetFullName()
        {
            if (MiddleName == null) return $"{FirstName} {LastName}";
            else return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}
