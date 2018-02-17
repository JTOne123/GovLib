using System;
using GovLib.Contracts;
using System.Globalization;
using GovLib.Util;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiSenatorsLeaving
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        
        [JsonProperty("party")]
        public string Party { get; set; }
        
        [JsonProperty("state")]
        public string State { get; set; }
    }
}
