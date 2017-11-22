using System;
using Gov.NET.Models;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiAllMembers
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string party { get; set; }
        public string govtrack_id { get; set; }
        public string cspan_id { get; set; }
        public string votesmart_id { get; set; }
        public string google_entity_id { get; set; }
        public string url { get; set; }
        public string in_office { get; set; }
        public string seniority { get; set; }
        public string next_election { get; set; }
        public string total_votes { get; set; }
        public string missed_votes { get; set; }
        public string total_present { get; set; }
        public string ocd_id { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string state { get; set; }
        public string missed_votes_pct { get; set; }
        public string votes_with_party_pct { get; set; }
    }
}
