using System;

namespace Exceptions.Election 
{
    [Serializable]
    public class SearchFailedException : Exception
    {
        public SearchFailedException() { }
        public SearchFailedException(string message) : base(message) { }
        public SearchFailedException(string message, Exception inner) : base(message, inner) { }
        protected SearchFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}