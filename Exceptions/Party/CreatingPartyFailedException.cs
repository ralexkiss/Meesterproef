using System;

namespace Exceptions.Party
{
    [Serializable]
    public class CreatingPartyFailedException : Exception
    {
        public CreatingPartyFailedException() { }
        public CreatingPartyFailedException(string message) : base(message) { }
        public CreatingPartyFailedException(string message, Exception inner) : base(message, inner) { }
        protected CreatingPartyFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}