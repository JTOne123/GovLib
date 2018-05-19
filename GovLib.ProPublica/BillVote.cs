using GovLib.Core;

namespace GovLib.ProPublica
{
    public class BillVote : Vote
    {
        # pragma warning disable CS1591

        public string BillID { get; internal set; }
        public string SponsorID { get; internal set; }
        public string Number { get; internal set; }
    }
}