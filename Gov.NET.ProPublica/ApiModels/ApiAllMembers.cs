using System;
using System.Globalization;
using Gov.NET.Models;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiAllMembers
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string title { get; set; }
        public string date_of_birth { get; set; }
        public string party { get; set; }
        public string govtrack_id { get; set; }
        public string cspan_id { get; set; }
        public string votesmart_id { get; set; }
        public string google_entity_id { get; set; }
        public string url { get; set; }
        public bool? in_office { get; set; }
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

        public static Politician Convert(ApiAllMembers entity)
        {
            if (entity == null)
                return null;
            
            var pol = new Politician();
            pol.ID = entity.id;
            pol.FirstName = entity.first_name;
            pol.LastName = entity.last_name;
            pol.Party = entity.party;
            pol.State = entity.state;
            pol.Seniority = Int32.Parse(entity.seniority);
            pol.OcdID = entity.ocd_id;
            pol.BirthDate = DateTime.ParseExact(entity.date_of_birth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            pol.InOffice = (bool) entity.in_office;
            pol.MissedVotesRatio = double.Parse(entity.missed_votes_pct) / 100;
            pol.PartyLoyaltyRatio = double.Parse(entity.votes_with_party_pct) / 100;

            if (entity.next_election != null)
                pol.NextElection = Int32.Parse(entity.next_election);

            if (!string.IsNullOrEmpty(entity.middle_name))
                pol.MiddleName = entity.middle_name;

            return pol;
        }
    }
}
