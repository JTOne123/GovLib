namespace GovLib.Models
{
    /// <summary>Base contract for implementing all representative types.</summary>
    public interface IRepresentative : IPolitician
    {
        #pragma warning disable CS1591

        int District { get; set; }
        bool AtLargeDistrict { get; set; }
        
        #pragma warning restore CS1591
    }
}