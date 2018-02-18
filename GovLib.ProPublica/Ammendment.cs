using System;
using GovLib.Core.Contracts;

namespace GovLib.ProPublica
{
    public class Ammendment : IAmmendment
    {
        public string Number { get; set; }
        public string Slug { get; set; }
        public Politician Sponsor { get; set; }
        public DateTime Introduced { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string LatestAction { get; set; }
        public DateTime LatestActionDate { get; set; }
    }
}