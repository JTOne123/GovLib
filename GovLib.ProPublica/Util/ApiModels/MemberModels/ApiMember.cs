using System;
using GovLib.Util;
using GovLib.Models;
using System.Globalization;
using GovLib.ProPublica.Util;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiMember
    {
        public string member_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string date_of_birth { get; set; }
        public string gender { get; set; }
        public string url { get; set; }
        public string times_topics_url { get; set; }
        public string times_tag { get; set; }
        public string govtrack_id { get; set; }
        public string cspan_id { get; set; }
        public string votesmart_id { get; set; }
        public string icpsr_id { get; set; }
        public string twitter_account { get; set; }
        public string facebook_account { get; set; }
        public string youtube_account { get; set; }
        public string crp_id { get; set; }
        public string google_entity_id { get; set; }
        public string rss_url { get; set; }
        public string domain { get; set; }
        public bool? in_office { get; set; }
        public string current_party { get; set; }
        public string most_recent_vote { get; set; }
        public ApiRole[] roles { get; set; }

        public static Politician Convert(ApiMember entity)
        {
            if (entity == null)
                return null;

            var chamber = entity.roles[0].chamber.ToLower();
            Politician pol;

            if (chamber == "senate")
                pol = new Senator();
            else
                pol = new Representative();

            pol.ID = entity.member_id;
            pol.FirstName = entity.first_name;
            pol.LastName = entity.last_name;
            pol.Party = entity.current_party;
            pol.State = (State) EnumConvert.StateCodeToEnum(entity.roles[0].state);
            pol.Seniority = (int) entity.roles[0].seniority;
            pol.OcdID = entity.roles[0].ocd_id;
            pol.BirthDate = DateTime.ParseExact(entity.date_of_birth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            pol.InOffice = (bool) entity.in_office;
            pol.MissedVotesRatio = (int) entity.roles[0].missed_votes_pct / 100;
            pol.PartyLoyaltyRatio = (int) entity.roles[0].votes_with_party_pct / 100;
            pol.NextElection = 1788 + (Int32.Parse(entity.roles[0].congress) * 2);

            if (entity.gender == "M")
                pol.Gender = Gender.Male;
            else
                pol.Gender = Gender.Female;

            if (!string.IsNullOrEmpty(entity.middle_name))
                pol.MiddleName = entity.middle_name;

            if (chamber == "senate")
                return ConvertSenator((Senator) pol, entity);
            else
                return ConvertRepresentative((Representative) pol, entity);
        }

        private static Representative ConvertRepresentative(Representative rep, ApiMember entity)
        {
            if (entity.roles[0].district == "At-Large")
            {
                rep.District = 1;
                rep.AtLargeDistrict = true;
            }
            else
            {
                rep.District = Int32.Parse(entity.roles[0].district);
                rep.AtLargeDistrict = false;
            }

            return rep;
        }

        private static Senator ConvertSenator(Senator sen, ApiMember entity)
        {
            sen.Rank = TextHelper.Capitalize(entity.roles[0].state_rank);
            sen.Class = (int) entity.roles[0].senate_class;
            return sen;
        }
        
        internal bool IsVotingMember()
        {
            return EnumConvert.StateCodeToEnum(this.roles[0].state) != null;
        }
    }
}
