using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.VoteModels
{
    internal class ApiVoteNomination
    {
        [JsonProperty("nomination_id")]
        internal string NominationID { get; set; }

        [JsonProperty("number")]
        internal string Number { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("agency")]
        internal string Agency { get; set; }
    }
}