using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.VoteModels
{
    internal class ApiVoteAmendment
    {
        [JsonProperty("amendment_id")]
        internal string AmendmentID { get; set; }
    }
}