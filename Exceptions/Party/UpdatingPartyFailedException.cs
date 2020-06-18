using System;

namespace Exceptions.Party
{
    [Serializable]
    public class UpdatingPartyFailedException : Exception
    {
        public UpdatingPartyFailedException() { }
        public UpdatingPartyFailedException(string message) : base(message) { }
        public UpdatingPartyFailedException(string message, Exception inner) : base(message, inner) { }
        protected UpdatingPartyFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}