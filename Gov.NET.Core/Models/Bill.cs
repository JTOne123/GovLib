using System;

namespace Gov.NET.Models
{
    public class Bill : IBill
    {
        # pragma warning disable CS1591

        public string ID { get; set; }
        public string Url { get; set; }
        public Chamber Chamber { get; set; }
        public string Title { get; set; }
        public string Sponsor { get; set; }
        public string GovTrackUrl { get; set; }
        public string CongressUrl { get; set; }
        public DateTime Introduced { get; set; }

        # pragma warning restore
    }
}