namespace GovLib.Models
{
    /// <summary>Full implementation for a senator.</summary>
    public class Senator : Politician, ISenator
    {
        #pragma warning disable CS1591

        public string Rank { get; set; }
        public int Class { get; set; }

        public override string ToString() => $"Senator {FullName} ({Party}) [{State}]";

        #pragma warning restore CS1591
    }
}
