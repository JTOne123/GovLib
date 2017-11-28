using System;
using Gov.NET.Common.Models.Contracts;
using Gov.NET.Models;

namespace Gov.NET.Common.Models.Cards
{
    public abstract class PoliticianCard : IPolitician
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Party { get; set; }
        public Enums.State State { get; set; }

        private string GetFullName()
        {
            if (string.IsNullOrEmpty(MiddleName)) return $"{FirstName} {LastName}";
            else return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}