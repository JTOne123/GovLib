using System;
using System.Globalization;
using GovLib.Contracts;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiBill
    {
        [JsonProperty("bill_id")]
        internal string BillID;
        
        [JsonProperty("bill_type")]
        internal string BillType;
        
        [JsonProperty("number")]
        internal string Number;
        
        [JsonProperty("bill_uri")]
        internal string BillUrl;
        
        [JsonProperty("title")]
        internal string Title;
        
        [JsonProperty("short_title")]
        internal string ShortTitle;
        
        [JsonProperty("sponsor_title")]
        internal string SponsorTitle;
        
        [JsonProperty("sponsor_id")]
        internal string SponsorID;
        
        [JsonProperty("sponsor_name")]
        internal string SponsorName;
        
        [JsonProperty("sponsor_state")]
        internal string SponsorState;
        
        [JsonProperty("sponsor_party")]
        internal string SponsorParty;
        
        [JsonProperty("sponsor_uri")]
        internal string SponsorUri;
        
        [JsonProperty("gpo_pdf_uri")]
        internal string GpoPdfUri;
        
        [JsonProperty("congressdotgov_url")]
        internal string CongressDotGovUrl;
        
        [JsonProperty("govtrack_url")]
        internal string GovTrackUrl;
        
        [JsonProperty("introduced_date")]
        internal string IntroducedDate;
        
        [JsonProperty("active")]
        internal bool Active;
        
        [JsonProperty("house_passage")]
        internal string HousePassage;
        
        [JsonProperty("senate_passage")]
        internal string SenatePassage;
        
        [JsonProperty("enacted")]
        internal string Enacted;
        
        [JsonProperty("vetoed")]
        internal string Vetoed;
        
        [JsonProperty("cosponsors")]
        internal int CoSponsors;
        
        [JsonProperty("committees")]
        internal string Committees;
        
        [JsonProperty("committee_codes")]
        internal string[] CommitteeCodes;
        
        [JsonProperty("subcommittee_codes")]
        internal string[] SubCommitteeCodes;
        
        [JsonProperty("primary_subject")]
        internal string PrimarySubject;
        
        [JsonProperty("summary")]
        internal string Summary;
        
        [JsonProperty("summary_short")]
        internal string ShortSummary;
        
        [JsonProperty("latest_major_action_date")]
        internal string LatestMajorActionDate;
        
        [JsonProperty("latest_major_action")]
        internal string LatestMajorAction;

        internal static Bill Convert(ApiBill entity, MemberCache cache)
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