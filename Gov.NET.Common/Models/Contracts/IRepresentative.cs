namespace Gov.NET.Models.Contracts
{
    public interface IRepresentative : IPolitician
    {
        int District { get; set; }
        bool AtLargeDistrict { get; set; }
    }
}