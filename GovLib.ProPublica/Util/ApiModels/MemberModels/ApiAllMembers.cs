using System;
using System.Globalization;
using GovLib.Util;
using GovLib.Contracts;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiAllMembers
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [JsonProperty("title")]
        public string Title { get; set; }
        
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        [JsonProperty("date_of_birth")]
        public DateTime DateOfBirth { get; set; }
        
        [JsonProperty("party")]
        public string Party { get; set; }
        
        [JsonProperty("govtrack_id")]
        public string GovTrackId { get; set; }
        
        [JsonProperty("cspan_id")]
        public string CspanId { get; set; }
        
        [JsonProperty("votesmart_id")]
        public string VoteSmartId { get; set; }
        
        [JsonProperty("google_entity_id")]
        public string GoogleEntityId { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("in_office")]
        public bool? InOffice { get; set; }
        
        [JsonProperty("seniority")]
        public int? Seniority { get; set; }
        
        [JsonProperty("next_election")]
        public string NextElection { get; set; }
        
        [JsonProperty("total_votes")]
        public int? TotalVotes { get; set; }
        
        [JsonProperty("missed_votes")]
        public int? MissedVotes { get; set; }
        
        [JsonProperty("total_present")]
        public int? TotalPresent { get; set; }
        
        [JsonProperty("ocd_id")]
        public string OcdId { get; set; }
        
        [JsonProperty("office")]
        public string Office { get; set; }
        
        [JsonProperty("phone")]
        public string Phone { get; set; }
        
        [JsonProperty("fax")]
        public string Fax { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("missed_votes_pct")]
        public double? PercentVotesMissed { get; set; }
        
        [JsonProperty("votes_with_party_pct")]
        public double? VotesWithPartyPercent { get; set; }

        internal static Politician Convert(ApiAllMembers entity, Chamber chamber)
        {
            Politician pol;

            if (entity == null) return null;
            
            if (chamber == Chamber.Senate) pol = new Senator();
            else pol = new Representative();

            pol.CongressID = entity.ID;
            pol.FirstName = entity.FirstName;
            pol.LastName = entity.LastName;
            pol.Party = entity.Party;
            pol.State = (State) EnumConvert.StateCodeToEnum(entity.State);

            pol.OcdID = entity.OcdId;
            pol.BirthDate = entity.DateOfBirth;
            pol.InOffice = (bool) entity.InOffice;

            if (entity.Seniority == null) pol.Seniority = 0;
            else pol.Seniority = (int) entity.Seniority;

            if (entity.PercentVotesMissed == null) pol.MissedVotesRatio = 0;
            else pol.MissedVotesRatio = (double) entity.PercentVotesMissed / 100;

            if (entity.VotesWithPartyPercent == null) pol.PartyLoyaltyRatio = 0;
            else pol.PartyLoyaltyRatio = (double) entity.VotesWithPartyPercent / 100;

            if (entity.TotalVotes == null) pol.VotesCast = 0;
            else pol.VotesCast = (int) entity.TotalVotes;

            if (entity.MissedVotes == null) pol.VotesMissed = 0;
            else pol.VotesMissed = (int) entity.MissedVotes;
            
            if (entity.TotalPresent == null) pol.VotesPresent = 0;
            else pol.VotesPresent = (int) entity.TotalPresent;
            
            if (entity.Gender == "M") pol.Gender = GovLib.Gender.Male;
            else pol.Gender = GovLib.Gender.Female;

            if (entity.NextElection != null) pol.NextElection = Int32.Parse(entity.NextElection);

            if (!string.IsNullOrEmpty(entity.MiddleName)) pol.MiddleName = entity.MiddleName;

            return pol;
        }
    }
}
