using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class AmendmentsWrapper<T> : WrapperInfo
    {
        [JsonProperty("amendments")]
        internal T[] Amendments;
    }
}