namespace GovLib.Core.Exceptions
{
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