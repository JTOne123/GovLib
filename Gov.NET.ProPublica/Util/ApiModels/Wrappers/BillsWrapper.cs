namespace Gov.NET.ProPublica.Util
{
    internal class BillsWrapper<T>
    {
        public string num_results { get; set; }
        public string offset { get; set; }
        public T[] bills { get; set; }
    }
}
