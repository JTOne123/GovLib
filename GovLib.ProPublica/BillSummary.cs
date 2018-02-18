using System;
using GovLib.Contracts;

namespace GovLib.ProPublica
{
    public class BillSummary : IBill
    {
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