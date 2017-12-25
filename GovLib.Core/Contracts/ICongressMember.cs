namespace GovLib.Contracts
{
    /// <summary>Contract for politicians with a valid Congress Directory ID.</summary>
    public interface ICongressMember
    {
        #pragma warning disable CS1591
        string CongressID { get; }
    }
}