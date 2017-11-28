using Gov.NET.Common.Models.Contracts;

namespace Gov.NET.Common.Models.Cards
{
    public class RepresentativeCard : PoliticianCard, IRepresentative
    {
        public int District { get; set; }
        public bool AtLargeDistrict { get; set; }
    }
}