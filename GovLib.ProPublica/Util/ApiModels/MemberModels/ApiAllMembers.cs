using System;
using System.Globalization;
using GovLib.Util;
using GovLib.Contracts;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiAllMembers
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string gender { get; set; }
        public string date_of_birth { get; set; }
        public string party { get; set; }
        public string govtrack_id { get; set; }
        public string cspan_id { get; set; }
        public string votesmart_id { get; set; }
        public string google_entity_id { get; set; }
        public string url { get; set; }
        public bool? in_office { get; set; }
        public int? seniority { get; set; }
        public string next_election { get; set; }
        public int? total_votes { get; set; }
        public int? missed_votes { get; set; }
        public int? total_present { get; set; }
        public string ocd_id { get; set; }
        public string office { get; set; }
        public string phone { get; set; }
        public string fax { get; set; }
        public string state { get; set; }
        public double? missed_votes_pct { get; set; }
        public double? votes_with_party_pct { get; set; }

        internal static Politician Convert(ApiAllMembers entity, Chamber chamber)
        {
            Politician pol;

            if (entity == null) return null;
            
            if (chamber == Chamber.Senate) pol = new Senator();
            else pol = new Representative();

            pol.CongressID = entity.id;
            pol.FirstName = entity.first_name;
            pol.LastName = entity.last_name;
            pol.Party = entity.party;
            pol.State = (State) EnumConvert.StateCodeToEnum(entity.state);

            pol.OcdID = entity.ocd_id;
            pol.BirthDate = DateTime.ParseExact(entity.date_of_birth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            pol.InOffice = (bool) entity.in_office;

            if (entity.seniority == null) pol.Seniority = 0;
            else pol.Seniority = (int) entity.seniority;

            if (entity.missed_votes_pct == null) pol.MissedVotesRatio = 0;
            else pol.MissedVotesRatio = (double) entity.missed_votes_pct / 100;

            if (entity.votes_with_party_pct == null) pol.PartyLoyaltyRatio = 0;
            else pol.PartyLoyaltyRatio = (double) entity.votes_with_party_pct / 100;

            if (entity.total_votes == null) pol.VotesCast = 0;
            else pol.VotesCast = (int) entity.total_votes;

            if (entity.missed_votes == null) pol.VotesMissed = 0;
            else pol.VotesMissed = (int) entity.missed_votes;
            
            if (entity.total_present == null) pol.VotesPresent = 0;
            else pol.VotesPresent = (int) entity.total_present;
            
            if (entity.gender == "M") pol.Gender = Gender.Male;
            else pol.Gender = Gender.Female;

            if (entity.next_election != null) pol.NextElection = Int32.Parse(entity.next_election);

            if (!string.IsNullOrEmpty(entity.middle_name)) pol.MiddleName = entity.middle_name;

            return pol;
        }
    }
}
