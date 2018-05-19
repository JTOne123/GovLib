using GovLib.Util;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.VoteModels
{
    internal class ApiVoteRollCallPosition
    {
        [JsonProperty("member_id")]
        internal string CongressID { get; set; }
        
        [JsonProperty("name")]
        internal string FullName { get; set; }
        
        [JsonProperty("party")]
        internal string Party { get; set; }
        
        [JsonProperty("state")]
        internal string State { get; set; }
        
        [JsonProperty("district")]
        internal string District { get; set; }
        
        [JsonProperty("vote_position")]
        internal string Position { get; set; }

        internal static VotePosition Convert(ApiVoteRollCallPosition entiity)
        {
            return new VotePosition
            {
                CongressID = entiity.CongressID,
                FullName = entiity.FullName,
                State = (State) EnumConvert.StateCodeToEnum(entiity.State),
                Vote = entiity.Position
            };
        }
    }
}