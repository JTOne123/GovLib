using Newtonsoft.Json;

namespace GovLib.ProPublica.Util
{
    internal class BillsWrapper<T> : WrapperInfo
    {
        [JsonProperty("bills")]
        public T[] Bills { get; set; }
    }
}
