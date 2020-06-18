using System;

namespace Exceptions.Party 
{
    [Serializable]
    public class GetPartyByIDFailedException : Exception
    {
        public GetPartyByIDFailedException() { }
        public GetPartyByIDFailedException(string message) : base(message) { }
        public GetPartyByIDFailedException(string message, Exception inner) : base(message, inner) { }
        protected GetPartyByIDFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}