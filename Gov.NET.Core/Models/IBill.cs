using Gov.NET.Models;

namespace Gov.NET.Core.Models
{
    public interface IBill
    {
        # pragma warning disable CS1591

        string ID { get; set; }
        string Url { get; set; }
        Chamber Chamber { get; }
        string Title { get; set; }
        Politician Sponsor { get; set; }
        string Text { get; set; }
        string TextSnippet { get; set; }

        # pragma warning restore

    }
}