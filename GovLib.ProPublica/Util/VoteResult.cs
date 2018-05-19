namespace GovLib.ProPublica.Util
{
    public class VoteResult
    {
        #pragma warning disable CS1591

        public int Yes { get; internal set; }
        public int No { get; internal set; }
        public int Present { get; internal set; }
        public int NotVoting { get; internal set; }
        public bool MajorityPosition { get; internal set; }
    }
}