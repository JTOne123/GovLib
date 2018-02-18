using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class SubjectsWrapper<T>
    {
        [JsonProperty("subjects")]
        internal T[] Subjects { get; set; }
    }
}