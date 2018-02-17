using System;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiCommittee
    {
        [JsonProperty("name")]
        public string Name {get;set;}
        
        [JsonProperty("api_url")]
        public string ApiUrl {get;set;}
        
        [JsonProperty("rank_in_party")]
        public string RankInParty {get;set;}
        
        [JsonProperty("begin_date")]
        public string BeginDate{get;set;}
        
        [JsonProperty("end_date")]
        public string EndDate {get;set;}
    }
}
