using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class VoteWrapper<T> : WrapperInfo
    {
        [JsonProperty("vote")]
        public T Votes { get; set; }
    }
}