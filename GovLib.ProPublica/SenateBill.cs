using GovLib.Contracts;

namespace GovLib.ProPublica
{
    /// <summary>
    /// Library model for a senate bill.
    /// </summary>
    public abstract class SenateBill : Bill
    {
        #pragma warning disable CS1591

        public new Senator Sponsor { get; }
        public new Chamber Chamber = Chamber.Senate;
    }
}