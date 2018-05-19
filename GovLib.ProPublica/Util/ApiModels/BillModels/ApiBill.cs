using System;
using System.Globalization;
using GovLib.Contracts;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiBill
    {
        [JsonProperty("bill_id")]
        internal string BillID { get; set; }
        
        [JsonProperty("bill_type")]
        internal string BillType { get; set; }

        [JsonProperty("bill_slug")]
        internal string BillSlug { get; set; }
        
        [JsonProperty("number")]
        internal string Number { get; set; }
        
        [JsonProperty("bill_uri")]
        internal string BillUrl { get; set; }
        
        [JsonProperty("title")]
        internal string Title { get; set; }
        
        [JsonProperty("short_title")]
        internal string ShortTitle { get; set; }
        
        [JsonProperty("sponsor_title")]
        internal string SponsorTitle { get; set; }
        
        [JsonProperty("sponsor_id")]
        internal string SponsorID { get; set; }
        
        [JsonProperty("sponsor_name")]
        internal string SponsorName { get; set; }
        
        [JsonProperty("sponsor_state")]
        internal string SponsorState { get; set; }
        
        [JsonProperty("sponsor_party")]
        internal string SponsorParty { get; set; }
        
        [JsonProperty("sponsor_uri")]
        internal string SponsorUri { get; set; }
        
        [JsonProperty("gpo_pdf_uri")]
        internal string GpoPdfUri { get; set; }
        
        [JsonProperty("congressdotgov_url")]
        internal string CongressDotGovUrl { get; set; }
        
        [JsonProperty("govtrack_url")]
        internal string GovTrackUrl { get; set; }
        
        [JsonProperty("introduced_date")]
        internal string IntroducedDate { get; set; }
        
        [JsonProperty("active")]
        internal bool Active { get; set; }
        
        [JsonProperty("house_passage")]
        internal string HousePassage { get; set; }
        
        [JsonProperty("senate_passage")]
        internal string SenatePassage { get; set; }
        
        [JsonProperty("enacted")]
        internal string Enacted { get; set; }
        
        [JsonProperty("vetoed")]
        internal string Vetoed { get; set; }
        
        [JsonProperty("cosponsors")]
        internal int CoSponsors { get; set; }
        
        [JsonProperty("committees")]
        internal string Committees { get; set; }
        
        [JsonProperty("committee_codes")]
        internal string[] CommitteeCodes { get; set; }
        
        [JsonProperty("subcommittee_codes")]
        internal string[] SubCommitteeCodes { get; set; }
        
        [JsonProperty("primary_subject")]
        internal string PrimarySubject { get; set; }
        
        [JsonProperty("summary")]
        internal string Summary { get; set; }
        
        [JsonProperty("summary_short")]
        internal string ShortSummary { get; set; }
        
        [JsonProperty("latest_major_action_date")]
        internal string LatestMajorActionDate { get; set; }
        
        [JsonProperty("latest_major_action")]
        internal string LatestMajorAction { get; set; }

        internal static Bill Convert(ApiBill entity)
        {
            if (entity == null)
                return null;
            
            var bill = new Bill()
            {
                BillID = entity.BillID,
                BillSlug = entity.BillSlug,
                Url = entity.BillUrl,
                Number = entity.Number,
                Title = entity.ShortTitle,
                BillType = entity.BillType,
                Introduced = DateTime.ParseExact(entity.IntroducedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                LatestAction = entity.LatestMajorAction,
                LatestActionDate = DateTime.ParseExact(entity.LatestMajorActionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                SponsorID = entity.SponsorID
            };
            
            return bill;
        }
    }
}