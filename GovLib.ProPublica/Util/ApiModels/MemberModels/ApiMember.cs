using System;
using GovLib.Util;
using GovLib.Contracts;
using System.Globalization;
using GovLib.ProPublica.Util;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiMember
    {
        [JsonProperty("member_id")]
        public string MemberID { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [JsonProperty("middle_name")]
        public string middle_name { get; set; }
        
        [JsonProperty("date_of_birth")]
        public string DateOfBirth { get; set; }
        
        [JsonProperty("gender")]
        public string Gender { get; set; }
        
        [JsonProperty("url")]
        public string Url { get; set; }
        
        [JsonProperty("times_topics_url")]
        public string TimesTopicUrl { get; set; }
        
        [JsonProperty("times_tag")]
        public string TimesTag { get; set; }
        
        [JsonProperty("govtrack_id")]
        public string GovTrackID { get; set; }
        
        [JsonProperty("cspan_id")]
        public string CspanID { get; set; }
        
        [JsonProperty("votesmart_id")]
        public string VoteSmartID { get; set; }
        
        [JsonProperty("icpsr_id")]
        public string IcpsrID { get; set; }
        
        [JsonProperty("twitter_account")]
        public string TwitterAccount { get; set; }
        
        [JsonProperty("facebook_account")]
        public string FacebookAccount { get; set; }
        
        [JsonProperty("youtube_account")]
        public string YouTubeAccount { get; set; }
        
        [JsonProperty("crp_id")]
        public string CrpID { get; set; }
        
        [JsonProperty("google_entity_id")]
        public string GoogleEntityID { get; set; }
        
        [JsonProperty("rss_url")]
        public string RssUrl { get; set; }
        
        [JsonProperty("domain")]
        public string Domain { get; set; }
        
        [JsonProperty("in_office")]
        public bool? InOffice { get; set; }
        
        [JsonProperty("current_party")]
        public string CurrentParty { get; set; }
        
        [JsonProperty("most_recent_vote")]
        public string MostRecentVote { get; set; }
        
        [JsonProperty("roles")]
        public ApiRole[] Roles { get; set; }

        public static Politician Convert(ApiMember entity)
        {
            if (entity == null)
                return null;

            var chamber = entity.Roles[0].Chamber.ToLower();
            Politician pol;

            if (chamber == "senate")
                pol = new Senator();
            else
                pol = new Representative();

            pol.CongressID = entity.MemberID;
            pol.FirstName = entity.FirstName;
            pol.LastName = entity.LastName;
            pol.Party = entity.CurrentParty;
            pol.State = (State) EnumConvert.StateCodeToEnum(entity.Roles[0].State);
            pol.Seniority = (int) entity.Roles[0].Seniority;
            pol.OcdID = entity.Roles[0].OcdID;
            pol.BirthDate = DateTime.ParseExact(entity.DateOfBirth, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            pol.InOffice = (bool) entity.InOffice;
            pol.MissedVotesRatio = (int) entity.Roles[0].MissedVotesPercent / 100;
            pol.PartyLoyaltyRatio = (int) entity.Roles[0].VotesWithPartyPercent / 100;
            pol.NextElection = 1788 + (Int32.Parse(entity.Roles[0].Congress) * 2);

            if (entity.Gender == "M")
                pol.Gender = GovLib.Gender.Male;
            else
                pol.Gender = GovLib.Gender.Female;

            if (!string.IsNullOrEmpty(entity.middle_name))
                pol.MiddleName = entity.middle_name;

            if (chamber == "senate")
                return ConvertSenator((Senator) pol, entity);
            else
                return ConvertRepresentative((Representative) pol, entity);
        }

        private static Representative ConvertRepresentative(Representative rep, ApiMember entity)
        {
            if (entity.Roles[0].District == "At-Large")
            {
                rep.District = 1;
                rep.AtLargeDistrict = true;
            }
            else
            {
                rep.District = Int32.Parse(entity.Roles[0].District);
                rep.AtLargeDistrict = false;
            }

            return rep;
        }

        private static Senator ConvertSenator(Senator sen, ApiMember entity)
        {
            sen.Rank = TextHelper.Capitalize(entity.Roles[0].StateRank);
            sen.Class = (int) entity.Roles[0].SenateClass;
            return sen;
        }
        
        internal bool IsVotingMember()
        {
            return EnumConvert.StateCodeToEnum(this.Roles[0].State) != null;
        }
    }
}
