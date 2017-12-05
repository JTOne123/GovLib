using Gov.NET.ProPublica.Util.MemberModels;

namespace Gov.NET.ProPublica.Util
{
    internal class NewMembersWrapper
    {
        public string num_results { get; set; }
        public string offset { get; set; }
        public ApiNewMembers[] members { get; set; }
    }
}
