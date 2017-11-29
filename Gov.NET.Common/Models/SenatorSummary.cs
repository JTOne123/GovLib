using Gov.NET.Models.Contracts;

namespace Gov.NET.Models.Summaries
{
    public class SenatorSummary : PoliticianSummary, ISenator
    {
        #pragma warning disable CS1591
        
        public string Rank { get; set; }
        public int Class { get; set; }

        #pragma warning restore CS1591
    }
}