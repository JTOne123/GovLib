using GovLib.Contracts;

namespace GovLib.ProPublica
{
    public abstract class PoliticianSummary : ICongressMember
    {
        #pragma warning disable CS1591

        public string CongressID { get; internal set; }
        public string FirstName { get; internal set; }
        public string MiddleName { get; internal set; }
        public string LastName { get; internal set; }
        public string FullName =>
            string.IsNullOrEmpty(MiddleName) ? $"{FirstName} {LastName}" : $"{FirstName} {MiddleName} {LastName}";
        public Party Party { get; internal set; }
        public State State { get; internal set; }
    }
}