using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class WrapperInfo
    {
        [JsonProperty("num_results")]
        public string Count { get; set; }
        
        [JsonProperty("offset")]
        public string Offset { get; set; }
    }
}
