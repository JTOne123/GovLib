using GovLib.Contracts;

namespace GovLib.ProPublica
{
    /// <summary>
    /// Library model for a house bill.
    /// </summary>
    public abstract class HouseBill : Bill
    {
        #pragma warning disable CS1591

        public new Representative Sponsor { get; }
        public new Chamber Chamber = Chamber.House;
    }
}