using System;

namespace Exceptions.PartyProfile
{
    [Serializable]
    public class UpdatingPartyProfileFailedException : Exception
    {
        public UpdatingPartyProfileFailedException() { }
        public UpdatingPartyProfileFailedException(string message) : base(message) { }
        public UpdatingPartyProfileFailedException(string message, Exception inner) : base(message, inner) { }
        protected UpdatingPartyProfileFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}