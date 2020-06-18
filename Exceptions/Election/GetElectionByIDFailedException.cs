using System;

namespace Exceptions.Election 
{
    [Serializable]
    public class GetElectionByIDFailedException : Exception
    {
        public GetElectionByIDFailedException() { }
        public GetElectionByIDFailedException(string message) : base(message) { }
        public GetElectionByIDFailedException(string message, Exception inner) : base(message, inner) { }
        protected GetElectionByIDFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}