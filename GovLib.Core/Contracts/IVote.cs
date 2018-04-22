namespace GovLib.Core
{
    public interface IVote
    {
        # pragma warning disable CS1591

        int Congress { get; }
        Chamber Chamber { get; }
        int Session { get; }
        int RollCall { get; }
    }
}