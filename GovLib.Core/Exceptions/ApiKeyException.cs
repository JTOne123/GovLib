namespace GovLib.Exceptions
{
    #pragma warning disable CS1591
    
    [System.Serializable]
    public class ApiKeyException : System.Exception
    {
        public ApiKeyException() { }
        public ApiKeyException(string message) : base(message) { }
        public ApiKeyException(string message, System.Exception inner) : base(message, inner) { }
        protected ApiKeyException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}