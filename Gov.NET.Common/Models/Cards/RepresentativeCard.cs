namespace Gov.NET.Common.Models.Cards
{
    public class RepresentativeCard : PoliticianCard
    {
        public int? District { get; set; }
        public bool? AtLargeDistrict { get; set; }
    }
}