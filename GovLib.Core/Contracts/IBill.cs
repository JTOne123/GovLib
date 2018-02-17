using System;

namespace GovLib.Contracts
{
    /// <summary>Contract for politicians with a valid Congress Directory ID.</summary>
    public interface IBill
    {
        # pragma warning disable CS1591

        string BillID { get; }
    }
}