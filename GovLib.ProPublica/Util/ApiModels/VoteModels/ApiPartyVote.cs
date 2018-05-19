using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.VoteModels
{
    internal class ApiPartyVote
    {
        [JsonProperty("yes")]
        internal int Yes { get; }
        
        [JsonProperty("no")]
        internal int No { get; }
        
        [JsonProperty("present")]
        internal int Present { get; }
        
        [JsonProperty("not_voting")]
        internal int NotVoting { get; }
        
        [JsonProperty("majority_position")]
        internal string Majority { get; }
    }
}