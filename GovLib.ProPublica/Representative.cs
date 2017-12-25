namespace GovLib.ProPublica
{
    /// <summary>Full implementation for a house representative.</summary>
    public class Representative : Politician
    {
        #pragma warning disable CS1591

        public int District { get; set; }
        public bool AtLargeDistrict { get; set; }
    }
}
