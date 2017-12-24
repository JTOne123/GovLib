namespace GovLib.Models
{
    /// <summary>Representative implementation of a PoliticianSummary. Contains limited information.</summary>
    public class RepresentativeSummary : PoliticianSummary, IRepresentative
    {
        #pragma warning disable CS1591

        public int District { get; set; }
        public bool AtLargeDistrict { get; set; }

        #pragma warning restore CS1591
    }
}