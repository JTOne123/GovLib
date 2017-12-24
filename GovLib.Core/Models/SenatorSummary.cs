namespace GovLib.Models
{
    /// <summary>Sentor implementation of a PoliticianSummary. Contains limited information.</summary>
    public class SenatorSummary : PoliticianSummary, ISenator
    {
        #pragma warning disable CS1591
        
        public string Rank { get; set; }
        public int Class { get; set; }

        #pragma warning restore CS1591
    }
}