namespace Gov.NET.ProPublica.ApiModels.Wrappers
{
    public class NewMembersWrapper
    {
        public string num_results { get; set; }
        public string offset { get; set; }
        public ApiNewMembers[] members { get; set; }
    }
}
