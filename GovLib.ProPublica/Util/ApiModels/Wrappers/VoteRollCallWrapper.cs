using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    public class VoteRollCallWrapper<T>
    {
        [JsonProperty("vote")]
        public T Vote { get; set; }
    }
}