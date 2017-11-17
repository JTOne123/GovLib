namespace Gov.NET.ProPublica.ApiModels.Wrappers
{
    public class ResultWrapper<T>
    {
        public string status { get; set; }
        public string copyright { get; set; }
        public T[] results { get; set; }
    }
}
