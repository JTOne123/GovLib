using GovLib.Contracts;

namespace GovLib.ProPublica
{
    public abstract class SenateBill : Bill
    {
        #pragma warning disable CS1591

        public new Senator Sponsor { get; }
        public new Chamber Chamber = Chamber.Senate;
    }
}