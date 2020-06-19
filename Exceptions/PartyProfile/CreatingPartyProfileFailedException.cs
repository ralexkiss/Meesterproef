using System;

namespace Exceptions.PartyProfile
{
    [Serializable]
    public class CreatingPartyProfileFailedException : Exception
    {
        public CreatingPartyProfileFailedException() { }
        public CreatingPartyProfileFailedException(string message) : base(message) { }
        public CreatingPartyProfileFailedException(string message, Exception inner) : base(message, inner) { }
        protected CreatingPartyProfileFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}