namespace Gov.NET.ProPublica.Util
{
    internal class ContainerWrapper<T>
    {
        public string congress { get; set; }
        public string chamber { get; set; }
        public string num_results { get; set; }
        public string offset { get; set; }
        public T[] members { get; set; }
    }
}
