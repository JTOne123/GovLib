using System;
using GovLib.Contracts;
using System.Globalization;
using GovLib.Util;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiSenatorsByState
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

        internal static SenatorSummary Convert(ApiSenatorsByState entity, string state)
        {
            if (entity == null) return null;

            var pol = new SenatorSummary();

            pol.CongressID = entity.ID;
            pol.FirstName = entity.FirstName;
            pol.MiddleName = entity.MiddleName;
            pol.LastName = entity.LastName;
            pol.State = (State) EnumConvert.StateCodeToEnum(state);
            pol.Party = entity.Party;

            return pol;
        }
    }
}
