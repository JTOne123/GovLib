using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.VoteModels
{
    internal class ApiVoteBill
    {
        [JsonProperty("bill_id")]
        internal string BillID { get; set; }

        [JsonProperty("number")]
        internal string Number { get; set; }

        [JsonProperty("sponsor_id")]
        internal string SponsorID { get; set; }

        [JsonProperty("title")]
        internal string Title { get; set; }
    }
}