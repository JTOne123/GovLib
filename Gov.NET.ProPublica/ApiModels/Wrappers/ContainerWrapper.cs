namespace Gov.NET.ProPublica.ApiModels.Wrappers
{
    public class ContainerWrapper<T>
    {
        public string congress { get; set; }
        public string chamber { get; set; }
        public string num_results { get; set; }
        public string offset { get; set; }
        public T[] members { get; set; }
    }
}
