namespace Gov.NET.Common.Models.Contracts
{
    public interface IRepresentative
    {
        int District { get; set; }
        bool AtLargeDistrict { get; set; }
    }
}