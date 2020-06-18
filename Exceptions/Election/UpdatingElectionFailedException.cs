using System;

namespace Exceptions.Election
{
    [Serializable]
    public class UpdatingElectionFailedException : Exception
    {
        public UpdatingElectionFailedException() { }
        public UpdatingElectionFailedException(string message) : base(message) { }
        public UpdatingElectionFailedException(string message, Exception inner) : base(message, inner) { }
        protected UpdatingElectionFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}