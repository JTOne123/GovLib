namespace GovLib.Exceptions
{
    #pragma warning disable CS1591

    [System.Serializable]
    public class EmptyCollectionException : System.Exception
    {
        public EmptyCollectionException() {}
        public EmptyCollectionException(string message) : base(message) {}
        public EmptyCollectionException(string message, System.Exception inner) : base(message, inner) {}
        protected EmptyCollectionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
    }
}