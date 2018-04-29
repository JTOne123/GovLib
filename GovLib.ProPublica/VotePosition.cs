namespace GovLib.ProPublica
{
    public class VotePosition
    {
        # pragma warning disable CS1591

        public string CongressID { get; internal set; }
        public string FullName { get; internal set; }
        public State State { get; internal set; }
        public string Vote { get; internal set; }
    }
}