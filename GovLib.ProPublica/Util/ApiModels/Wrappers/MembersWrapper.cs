using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class MembersWrapper<T> : WrapperInfo
    {
        [JsonProperty("congress")]
        public string Congress { get; set; }
        
        [JsonProperty("chamber")]
        public string Chamber { get; set; }
        
        [JsonProperty("members")]
        public T[] Members { get; set; }
    }
}
