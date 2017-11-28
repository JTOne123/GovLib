using Gov.NET.Models;
using Gov.NET.Models.Contracts;

namespace Gov.NET.Models.Summaries
{
    public abstract class PoliticianSummary : IPolitician
    {
        public string ID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Party { get; set; }
        public Enums.State State { get; set; }
        public string FullName =>
            string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
    }
}