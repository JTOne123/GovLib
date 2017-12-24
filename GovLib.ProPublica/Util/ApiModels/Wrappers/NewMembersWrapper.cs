using GovLib.ProPublica.Util.MemberModels;

namespace GovLib.ProPublica.Util
{
    internal class NewMembersWrapper
    {
        public string num_results { get; set; }
        public string offset { get; set; }
        public ApiNewMembers[] members { get; set; }
    }
}
