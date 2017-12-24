namespace GovLib.ProPublica.Util
{
    internal class ResultWrapper<T>
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public T[] results { get; set; }
    }
}
