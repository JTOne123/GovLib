using System;

namespace GovLib.Contracts
{
    public interface IBill
    {
        # pragma warning disable CS1591

        string ID { get; set; }
        string Url { get; set; }
        Chamber Chamber { get; }
        string Title { get; set; }
        string Sponsor { get; set; }
        DateTime Introduced { get; set; }

    }
}