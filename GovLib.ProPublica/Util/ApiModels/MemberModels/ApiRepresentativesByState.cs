using System;
using GovLib.Contracts;
using System.Globalization;
using GovLib.Util;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiRepresentativesByState
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
        
        [JsonProperty("district")]
        public string District { get; set; }

        internal static RepresentativeSummary Convert(ApiRepresentativesByState entity, string state)
        {
            if (entity == null) return null;

            var pol = new RepresentativeSummary();

            pol.CongressID = entity.ID;
            pol.FirstName = entity.FirstName;
            pol.MiddleName = entity.MiddleName;
            pol.LastName = entity.LastName;
            pol.State = (State) EnumConvert.StateCodeToEnum(state);
            pol.Party = (Party) EnumConvert.PartyLetterToEnum(entity.Party);

            if (entity.District == "At-Large") pol.District = 1;
            else pol.District = int.Parse(entity.District);

            return pol;
        }
    }
}
