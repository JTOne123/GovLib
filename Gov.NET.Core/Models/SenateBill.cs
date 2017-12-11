using Gov.NET.Models;

namespace Gov.NET.Models
{
    public class SenateBill: Bill
    {
        # pragma warning disable CS1591

        public Chamber Chamber { get; } = Chamber.Senate;

        # pragma warning restore
    }
}