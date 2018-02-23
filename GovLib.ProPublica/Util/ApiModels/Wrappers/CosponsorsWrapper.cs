using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class CosponsorsWrapper<T>
    {
        [JsonProperty("cosponsors")]
        internal T[] Cosponsors { get; set; }
    }
}
