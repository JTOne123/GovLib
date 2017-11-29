namespace Gov.NET.Models.Contracts
{
    public interface IPolitician
    {
        #pragma warning disable CS1591
        
        string ID { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        string Party { get; set; }
        State State { get; set; }

        #pragma warning restore CS1591
    }
}