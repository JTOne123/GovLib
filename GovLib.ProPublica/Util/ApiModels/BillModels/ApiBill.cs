using System;
using System.Globalization;
using GovLib.Contracts;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiBill
    {
        [JsonProperty("bill_id")]
        public string BillID;
        
        [JsonProperty("bill_type")]
        public string BillType;
        
        [JsonProperty("number")]
        public string Number;
        
        [JsonProperty("bill_uri")]
        public string BillUrl;
        
        [JsonProperty("title")]
        public string Title;
        
        [JsonProperty("short_title")]
        public string ShortTitle;
        
        [JsonProperty("sponsor_title")]
        public string SponsorTitle;
        
        [JsonProperty("sponsor_id")]
        public string SponsorID;
        
        [JsonProperty("sponsor_name")]
        public string SponsorName;
        
        [JsonProperty("sponsor_state")]
        public string SponsorState;
        
        [JsonProperty("sponsor_party")]
        public string SponsorParty;
        
        [JsonProperty("sponsor_uri")]
        public string SponsorUri;
        
        [JsonProperty("gpo_pdf_uri")]
        public string GpoPdfUri;
        
        [JsonProperty("congressdotgov_url")]
        public string CongressDotGovUrl;
        
        [JsonProperty("govtrack_url")]
        public string GovTrackUrl;
        
        [JsonProperty("introduced_date")]
        public string IntroducedDate;
        
        [JsonProperty("active")]
        public bool Active;
        
        [JsonProperty("house_passage")]
        public string HousePassage;
        
        [JsonProperty("senate_passage")]
        public string SenatePassage;
        
        [JsonProperty("enacted")]
        public string Enacted;
        
        [JsonProperty("vetoed")]
        public string Vetoed;
        
        [JsonProperty("cosponsors")]
        public int CoSponsors;
        
        [JsonProperty("committees")]
        public string Committees;
        
        [JsonProperty("committee_codes")]
        public string[] CommitteeCodes;
        
        [JsonProperty("subcommittee_codes")]
        public string[] SubCommitteeCodes;
        
        [JsonProperty("primary_subject")]
        public string PrimarySubject;
        
        [JsonProperty("summary")]
        public string Summary;
        
        [JsonProperty("summary_short")]
        public string ShortSummary;
        
        [JsonProperty("latest_major_action_date")]
        public string LatestMajorActionDate;
        
        [JsonProperty("latest_major_action")]
        public string LatestMajorAction;

        public static Bill Convert(ApiBill entity, MemberCache cache)
        {
            if (entity == null)
                return null;
            
            var bill = new Bill();

            bill.BillID = entity.BillID;
            bill.Url = entity.BillUrl;
            bill.Title = entity.ShortTitle;
            bill.BillType = entity.BillType;
            bill.Introduced = DateTime.ParseExact(entity.IntroducedDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            bill.LatestAction = entity.LatestMajorAction;
            bill.LatestActionDate = DateTime.ParseExact(entity.LatestMajorActionDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            bill.SponsorID = entity.SponsorID;

            if (entity.SponsorTitle == "Sen.")
                bill.Sponsor = cache.Senators[entity.SponsorID];
            else
                bill.Sponsor = cache.Representatives[entity.SponsorID];
            
            return bill;
        }
    }
}