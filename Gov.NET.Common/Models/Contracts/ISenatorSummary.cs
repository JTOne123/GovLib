namespace Gov.NET.Models.Contracts
{
    public interface ISenatorSummary : IPoliticianSummary
    {
        string Rank { get; set; }
        int Class { get; set; }
    }
}
