using System;
using Gov.NET.Util;

namespace Gov.NET.ProPublica.ApiModels
{
    public class ApiMember
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
        public string in_office { get; set; }
        public string current_party { get; set; }
        public string most_recent_vote { get; set; }
        public ApiRole[] roles { get; set; }

        public static Gov.NET.Models.Politician Convert(ApiMember entity, string chamber)
        {
            if (entity == null)
                return null;

            Gov.NET.Models.Politician politician;

            if (chamber == "senate")
            {
                politician = new Gov.NET.Models.Senator()
                {
                    Rank = Text.Capitalize(entity.roles[0].state_rank),
                    Class = Int32.Parse(entity.roles[0].senate_class)
                };
            }
            else
            {
                politician = new Gov.NET.Models.Representative()
                {
                    District = Int32.Parse(entity.roles[0].district)
                };
            }

            politician.ID = entity.member_id;
            politician.FirstName = entity.first_name;

            if (!string.IsNullOrEmpty(entity.middle_name))
                politician.MiddleName = entity.middle_name;

            politician.LastName = entity.last_name;
            politician.Party = entity.current_party;
            politician.State = entity.roles[0].state;
            politician.Seniority = Int32.Parse(entity.roles[0].seniority);
            politician.OcdID = entity.roles[0].ocd_id;

            return politician;
        }

        public static Gov.NET.Models.Politician ConvertMember(ApiMember entity)
        {
            if (entity == null)
                return null;

            Gov.NET.Models.Politician politician;

            if (entity.roles[0].chamber == "Senate")
            {
                politician = new Gov.NET.Models.Senator
                {
                    Rank = Text.Capitalize(entity.roles[0].state_rank),
                    Class = Int32.Parse(entity.roles[0].senate_class)
                };
            }
            else
            {
                politician = new Gov.NET.Models.Representative
                {
                    District = Int32.Parse(entity.roles[0].district)
                };
            }

            politician.ID = entity.member_id;
            politician.FirstName = entity.first_name;

            if (!string.IsNullOrEmpty(entity.middle_name))
                politician.MiddleName = entity.middle_name;

            politician.LastName = entity.last_name;
            politician.Party = entity.current_party;
            politician.State = entity.roles[0].state;
            politician.Seniority = Int32.Parse(entity.roles[0].seniority);
            politician.OcdID = entity.roles[0].ocd_id;

            return politician;
        }
    }
}
