using System;
using System.Globalization;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiAmendment
    {
        [JsonProperty("amendment_number")]
        internal string AmendmentNmber { get; set; }
        
        [JsonProperty("slug")]
        internal string Slug { get; set; }
        
        [JsonProperty("sponsor_id")]
        internal string SponsorID { get; set; }

        [JsonProperty("sponsor_title")]
        internal string SponsorTitle { get; set; }
        
        [JsonProperty("introduced_date")]
        internal string IntroducedDate { get; set; }
        
        [JsonProperty("title")]
        internal string Title { get; set; }
        
        [JsonProperty("cogressdotgov_url")]
        internal string Url { get; set; }
        
        [JsonProperty("latest_major_action")]
        internal string LatestAction { get; set; }
        
        [JsonProperty("latest_major_action_date")]
        internal string LatestActionDate { get; set; }

        internal static Amendment Convert(ApiAmendment entity, MemberCache cache)
        {
            if (entity == null)
                return null;
            
            var amendment = new Amendment()
            {
                Number = entity.AmendmentNmber,
                Slug = entity.Slug,
                Introduced = DateTime.ParseExact(entity.IntroducedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Title = entity.Title,
                Url = entity.Url,
                LatestAction = entity.LatestAction,
                LatestActionDate = DateTime.ParseExact(entity.IntroducedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };

            if (entity.SponsorTitle == "Sen.")
                amendment.Sponsor = cache.Senators[entity.SponsorID];
            else
                amendment.Sponsor = cache.Representatives[entity.SponsorID];
            
            return amendment;
        }
    }
}