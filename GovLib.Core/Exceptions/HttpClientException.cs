namespace GovLib.Core.Exceptions
{
    #pragma warning disable CS1591
    
    [System.Serializable]
    public class HttpClientException : System.Exception
    {
        public HttpClientException() { }
        public HttpClientException(string message) : base(message) { }
        public HttpClientException(string message, System.Exception inner) : base(message, inner) { }
        protected HttpClientException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}