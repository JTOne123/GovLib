using GovLib.Contracts;

namespace GovLib.ProPublica
{
    public abstract class HouseBill : Bill
    {
        #pragma warning disable CS1591

        public new Representative Sponsor { get; }
        public new Chamber Chamber = Chamber.House;
    }
}