using System;
using GovLib.Contracts;

namespace GovLib.ProPublica
{
    /// <summary>
    /// Basic bill info for API requests that return limited data.
    /// </summary>
    public class BillSummary : IBill
    {
        #pragma warning disable CS1591

        public string BillID { get; set; }
        public string BillType { get; set; }
        public string BillSlug { get; set; }
        public string Number { get; set; }
        public string BillUrl { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledAt { get; set; }
        public Chamber Chamber { get; set; }
        public int Congress { get; set; }
    }
}