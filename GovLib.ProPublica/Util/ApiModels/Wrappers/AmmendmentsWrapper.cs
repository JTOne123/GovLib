using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class AmmendmentsWrapper<T> : WrapperInfo
    {
        [JsonProperty("ammendments")]
        internal T[] Ammendments;
    }
}