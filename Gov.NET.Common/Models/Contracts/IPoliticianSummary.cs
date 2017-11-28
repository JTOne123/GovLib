using System;
using Gov.NET.Models.Contracts;
using Gov.NET.Models;

namespace Gov.NET.Models.Contracts
{
    public interface IPoliticianSummary : IPolitician
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