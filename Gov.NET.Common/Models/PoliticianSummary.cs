using Gov.NET.Models;
using Gov.NET.Models.Contracts;

namespace Gov.NET.Models.Summaries
{
    /// <summary>Abstract implementation of the IPolitician interface. Contains only basic information.</summary>
    public abstract class PoliticianSummary : IPolitician
    {
        #pragma warning disable CS1591

        public string ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Party { get; set; }
        public State State { get; set; }
        public string FullName =>
            string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
            
        #pragma warning restore CS1591
    }
}