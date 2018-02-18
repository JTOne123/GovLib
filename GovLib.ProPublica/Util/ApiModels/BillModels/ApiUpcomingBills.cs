using System;
using System.Globalization;
using GovLib;
using GovLib.Contracts;
using GovLib.Util;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    #pragma warning disable CS1591
    internal class ApiUpcomingBills
    {
        [JsonProperty("bill_id")]
        internal string BillID;
        
        [JsonProperty("bill_type")]
        internal string BillType;

        [JsonProperty("bill_slug")]
        internal string BillSlug;
        
        [JsonProperty("bill_uri")]
        internal string BillUrl;
        
        [JsonProperty("description")]
        internal string Description;

        [JsonProperty("scheduled_at")]
        internal string ScheduledAt;

        [JsonProperty("chamber")]
        internal string Chamber;

        [JsonProperty("congress")]
        internal int Congress;


        internal static BillSummary Convert(ApiUpcomingBills entity)
        {
            if (entity == null)
                return null;
            
            var bill = new BillSummary();

            bill.BillID = entity.BillID;
            bill.BillType = entity.BillType;
            bill.BillSlug = entity.BillSlug;
            bill.BillUrl = entity.BillUrl;
            bill.Description = entity.Description;
            bill.ScheduledAt = DateTime.ParseExact(entity.ScheduledAt, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            bill.Congress = entity.Congress;
            
            if (entity.Chamber == "senate") bill.Chamber = GovLib.Chamber.Senate;
            else bill.Chamber = GovLib.Chamber.House;
            
            return bill;
        }
    }
}