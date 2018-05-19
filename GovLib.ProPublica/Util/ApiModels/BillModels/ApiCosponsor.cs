using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.BillModels
{
    internal class ApiCosponsor
    {
        [JsonProperty("cosponsor_id")]
        internal string ID { get; set; }

        [JsonProperty("name")]
        internal string Name { get; set; }

        [JsonProperty("cosponsor_title")]
        internal string Title { get; set; }

        [JsonProperty("cosponsor_state")]
        internal string State { get; set; }

        [JsonProperty("cosponsor_party")]
        internal string Party { get; set; }

        [JsonProperty("date")]
        internal string Date { get; set; }
    }
}