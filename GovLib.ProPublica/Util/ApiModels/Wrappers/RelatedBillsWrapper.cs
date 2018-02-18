using Newtonsoft.Json;

namespace GovLib.ProPublica.Util.ApiModels.Wrappers
{
    internal class RelatedBillsWrapper<T>
    {
        [JsonProperty("related_bills")]
        internal T[] RelatedBills { get; set; }
    }
}