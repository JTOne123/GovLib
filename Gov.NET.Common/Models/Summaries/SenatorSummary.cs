using Gov.NET.Models.Contracts;

namespace Gov.NET.Models.Summaries
{
    public class SenatorSummary : PoliticianSummary, ISenator
    {
        public string Rank { get; set; }
        public int Class { get; set; }
    }
}