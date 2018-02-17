using GovLib.ProPublica.Util.MemberModels;
using Newtonsoft.Json;

namespace GovLib.ProPublica.Util
{
    internal class NewMembersWrapper : WrapperInfo
    {
        [JsonProperty("members")]
        public ApiNewMembers[] Members { get; set; }
    }
}
