using System;
namespace Gov.NET.ProPublica.Util
{
    internal class ApiRole
    {
        public string congress { get; set; }
        public string chamber { get; set; }
        public string title { get; set; }
        public string state { get; set; }
        public string party { get; set; }
        public string leadership_role { get; set; }
        public string fec_candidate_id { get; set; }
        public int? seniority { get; set; }
        public int? senate_class { get; set; }
        public string state_rank { get; set; }
        public string district { get; set; }
        public string lis_id { get; set; }
        public string ocd_id { get; set; }
        public string start_date { get; set; }
        public string end_date { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string contact_form { get; set; }
        public int? bills_sponsored { get; set; }
        public int? bills_cosponsored { get; set; }
        public double? missed_votes_pct { get; set; }
        public double? votes_with_party_pct { get; set; }
        public ApiCommittee[] committees { get; set; }
    }
}
