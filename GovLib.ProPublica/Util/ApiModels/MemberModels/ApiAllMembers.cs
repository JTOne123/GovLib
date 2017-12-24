using System;
using System.Globalization;
using GovLib.Util;
using GovLib.Models;

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

        public static Politician Convert(ApiAllMembers entity)
        {
            if (entity == null)
                return null;
            
            var pol = new Politician();
            pol.ID = entity.id;
            pol.FirstName = entity.first_name;
            pol.LastName = entity.last_name;
            pol.Party = entity.party;
            pol.State = (State) EnumConvert.StateCodeToEnum(entity.state);
            pol.Seniority = (int) entity.seniority;
            pol.OcdID = entity.ocd_id;
            pol.BirthDate = DateTime.ParseExact(entity.date_of_birth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            pol.InOffice = (bool) entity.in_office;
            pol.MissedVotesRatio = (double) entity.missed_votes_pct / 100;
            pol.PartyLoyaltyRatio = (double) entity.votes_with_party_pct / 100;
            pol.VotesCast = (int) entity.total_votes;
            pol.VotesMissed = (int) entity.missed_votes;
            pol.VotesPresent = (int) entity.total_present;
            
            if (entity.gender == "M")
                pol.Gender = Gender.Male;
            else
                pol.Gender = Gender.Female;

            if (entity.next_election != null)
                pol.NextElection = Int32.Parse(entity.next_election);

            if (!string.IsNullOrEmpty(entity.middle_name))
                pol.MiddleName = entity.middle_name;

            return pol;
        }
    }
}
