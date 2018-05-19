using System;
using System.Globalization;
using GovLib.Contracts;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.MemberModels
{
    internal class ApiAllReps : ApiAllMembers
    {
        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("at_large")]
        public bool AtLarge { get; set; }

        internal static Representative Convert(ApiAllReps entity)
        {
            var rep = ApiAllMembers.Convert(entity, Chamber.House) as Representative;

            if (entity.District == "At-Large")
            {
                rep.District = 1;
                rep.AtLargeDistrict = true;
            }
            else
            {
                rep.District = Int32.Parse(entity.District);
                rep.AtLargeDistrict = false;
            }
            
            return rep;
        }

        internal bool IsVotingMember()
        {
            return this.Title == "Representative";
        }
    }
}
