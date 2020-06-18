using System;

namespace Exceptions.Party
{
    [Serializable]
    public class PartyNotFoundException : Exception
    {
        public PartyNotFoundException() { }
        public PartyNotFoundException(string message) : base(message) { }
        public PartyNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected PartyNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}