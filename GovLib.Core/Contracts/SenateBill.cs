namespace GovLib.Contracts
{
    public class SenateBill: Bill
    {
        # pragma warning disable CS1591

        public Chamber Chamber { get; } = Chamber.Senate;
    }
}