using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class ResultsWrapper<T>
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        
        [JsonProperty("copyright")]
        public string Copyright { get; set; }
        
        [JsonProperty("results")]
        public T[] Results { get; set; }
    }
}
