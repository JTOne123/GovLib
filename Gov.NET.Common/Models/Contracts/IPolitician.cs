using Gov.NET.Models;

namespace Gov.NET.Common.Models.Contracts
{
    public interface IPolitician
    {
        string ID { get; set; }
        string FirstName { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
        string FullName { get; }
        string Party { get; set; }
        Enums.State State { get; set; }
    }
}