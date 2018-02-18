using System;
using System.Globalization;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiAmmendment
    {
        [JsonProperty("ammendment_number")]
        internal string AmmendmentNmber { get; set; }
        
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

        internal static Ammendment Convert(ApiAmmendment entity, MemberCache cache)
        {
            if (entity == null)
                return null;
            
            var ammendment = new Ammendment()
            {
                Number = entity.AmmendmentNmber,
                Slug = entity.Slug,
                Introduced = DateTime.ParseExact(entity.IntroducedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                Title = entity.Title,
                Url = entity.Url,
                LatestAction = entity.LatestAction,
                LatestActionDate = DateTime.ParseExact(entity.IntroducedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture)
            };

            if (entity.SponsorTitle == "Sen.")
                ammendment.Sponsor = cache.Senators[entity.SponsorID];
            else
                ammendment.Sponsor = cache.Representatives[entity.SponsorID];
            
            return ammendment;
        }
    }
}