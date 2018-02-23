namespace GovLib.Exceptions
{
    [System.Serializable]
    #pragma warning disable CS1591
    public class MemberNotInCacheException : System.Exception
    {
        public MemberNotInCacheException() {}
        public MemberNotInCacheException(string message) : base(message) {}
        public MemberNotInCacheException(string message, System.Exception inner) : base(message, inner) {}
        protected MemberNotInCacheException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) {}
    }
}