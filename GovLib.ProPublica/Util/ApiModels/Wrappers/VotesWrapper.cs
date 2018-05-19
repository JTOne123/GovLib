using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class VotesWrapper<T> : WrapperInfo
    {
        [JsonProperty("chamber")]
        public string Chamber { get; set; }

        [JsonProperty("votes")]
        public T[] Votes { get; set; }
    }
}