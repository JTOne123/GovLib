using System;
using System.Globalization;
using GovLib.Contracts;
using GovLib.Util;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiAllSenators : ApiAllMembers
    {
        [JsonProperty("senate_class")]
        public string SenateClass { get; set; }

        [JsonProperty("state_rank")]
        public string StateRank { get; set; }

        internal static Senator Convert(ApiAllSenators entity)
        {
            var sen = ApiAllMembers.Convert(entity, Chamber.Senate) as Senator;

            sen.Class = Int32.Parse(entity.SenateClass);

            if (sen.InOffice)
            {
                if (entity.StateRank == "") sen.Rank = "Junior";
                else sen.Rank = TextHelper.Capitalize(entity.StateRank);
            }
            
            return sen;
        }
    }
}
