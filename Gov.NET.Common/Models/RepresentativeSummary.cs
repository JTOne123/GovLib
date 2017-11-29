using Gov.NET.Models.Contracts;

namespace Gov.NET.Models.Summaries
{
    public class RepresentativeSummary : PoliticianSummary, IRepresentative
    {
        #pragma warning disable CS1591

        public int District { get; set; }
        public bool AtLargeDistrict { get; set; }

        #pragma warning restore CS1591
    }
}