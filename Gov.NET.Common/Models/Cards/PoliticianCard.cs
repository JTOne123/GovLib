using System;

namespace Gov.NET.Common.Models.Cards
{
    public abstract class PoliticianCard
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FullName => GetFullName();
        public string Party { get; set; }
        public string State { get; set; }
        public DateTime? StartDate { get; set; }
        
        private string GetFullName()
        {
            if (string.IsNullOrEmpty(MiddleName)) return $"{FirstName} {LastName}";
            else return $"{FirstName} {MiddleName} {LastName}";
        }
    }
}