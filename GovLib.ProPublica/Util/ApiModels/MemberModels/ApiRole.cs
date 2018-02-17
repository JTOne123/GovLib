using System;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiRole
    {
        [JsonProperty("congress")]
        public string Congress { get; set; }
        
        [JsonProperty("chamber")]
        public string Chamber { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("party")]
        public string Party { get; set; }
        
        [JsonProperty("leadership_role")]
        public string LeadershipRole { get; set; }
        
        [JsonProperty("fec_candidate_id")]
        public string FecCandidateID { get; set; }
        
        [JsonProperty("seniority")]
        public int? Seniority { get; set; }
        
        [JsonProperty("senate_class")]
        public int? SenateClass { get; set; }
        
        [JsonProperty("state_rank")]
        public string StateRank { get; set; }
        
        [JsonProperty("district")]
        public string District { get; set; }
        
        [JsonProperty("lis_id")]
        public string LisID { get; set; }
        
        [JsonProperty("ocd_id")]
        public string OcdID { get; set; }
        
        [JsonProperty("start_date")]
        public string StartDate { get; set; }
        
        [JsonProperty("end_date")]
        public string end_date { get; set; }
        
        [JsonProperty("office")]
        public string Office { get; set; }
        
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        [JsonProperty("fax")]
        public string Fax { get; set; }
        
        [JsonProperty("contact_form")]
        public string ContactForm { get; set; }
        
        [JsonProperty("bills_sponsored")]
        public int? BillsSponsored { get; set; }
        
        [JsonProperty("bills_cosponsored")]
        public int? BillsCosponsored { get; set; }
        
        [JsonProperty("missed_votes_pct")]
        public double? MissedVotesPercent { get; set; }
        
        [JsonProperty("votes_with_party_pct")]
        public double? VotesWithPartyPercent { get; set; }
        
        [JsonProperty("committees")]
        public ApiCommittee[] Committees { get; set; }
    }
}
