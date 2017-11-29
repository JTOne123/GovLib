namespace Gov.NET.Models.Contracts
{
    public interface IRepresentative : IPolitician
    {
        #pragma warning disable CS1591

        int District { get; set; }
        bool AtLargeDistrict { get; set; }
        
        #pragma warning restore CS1591
    }
}