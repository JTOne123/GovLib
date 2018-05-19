namespace GovLib.ProPublica
{
    public class NominationVote : Vote
    {
        # pragma warning disable CS1591

        public string NominationID { get; internal set; }
        public string Number { get; internal set; }
        public string Name { get; internal set; }
        public string Agency { get; internal set; }
    }
}