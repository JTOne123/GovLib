using Gov.NET.Models.Contracts;

namespace Gov.NET.Models.Summaries
{
    public class RepresentativeSummary : PoliticianSummary, IRepresentative
    {
        public int District { get; set; }
        public bool AtLargeDistrict { get; set; }
    }
}