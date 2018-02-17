using System;

namespace GovLib.Exceptions
{
    #pragma warning disable CS1591
    public class EmptyApiKeyException : InvalidOperationException
    {
        public EmptyApiKeyException() {}

        public EmptyApiKeyException(string message) : base(message) {}

        public EmptyApiKeyException(string message, Exception inner) : base(message, inner) {}
    }
}