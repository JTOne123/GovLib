using Gov.NET.Models;

namespace Gov.NET.Core.Models
{
    public class HouseBill : Bill
    {
        # pragma warning disable CS1591

        public Chamber Chamber { get; } = Chamber.House;

        # pragma warning restore
    }
}