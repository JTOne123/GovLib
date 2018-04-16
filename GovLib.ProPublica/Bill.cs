using System;
using GovLib.Contracts;

namespace GovLib.ProPublica
{
    /// <summary>
    /// Library model for a congressional bill.
    /// </summary>
    public class Bill : IBill
    {
        #pragma warning disable CS1591

        public string BillID { get; internal set; }
        public string BillType { get; internal set; }
        public string BillSlug { get; internal set; }
        public string Number { get; internal set; }
        public string Url { get; internal set; }
        public string Title { get; internal set; }
        public string SponsorID { get; internal set; }
        public Chamber Chamber { get; internal set; }
        public string CongressUrl { get; internal set; }
        public string GovTrackUrl { get; internal set; }
        public DateTime Introduced { get; set; }
        public string LatestAction { get; internal set; }
        public DateTime LatestActionDate { get; internal set; }
        public bool Active { get; internal set; }
        public bool PassedHouse { get; internal set; }
        public bool PassedSenate { get; internal set; }
        public bool Enacted { get; internal set; }
        public bool Vetoed { get; internal set; }
        public int CoFounders { get; internal set; }
    }
}