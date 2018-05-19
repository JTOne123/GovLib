using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class BillsWrapper<T> : WrapperInfo
    {
        [JsonProperty("bills")]
        public T[] Bills { get; set; }
    }
}
