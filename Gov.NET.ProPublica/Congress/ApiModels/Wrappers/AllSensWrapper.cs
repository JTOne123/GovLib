namespace Gov.NET.ProPublica.ApiModels.Wrappers
{
    public class AllSenatorsWrapper
    {
        public string congress { get; set; }
        public string chamber { get; set; }
        public string num_results { get; set; }
        public string offset { get; set; }
        public ApiAllSenators[] members { get; set; }
    }
}
