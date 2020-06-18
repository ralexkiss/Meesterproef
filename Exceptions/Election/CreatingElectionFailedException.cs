using System;

namespace Exceptions.Election
{
    [Serializable]
    public class CreatingElectionFailedException : Exception
    {
        public CreatingElectionFailedException() { }
        public CreatingElectionFailedException(string message) : base(message) { }
        public CreatingElectionFailedException(string message, Exception inner) : base(message, inner) { }
        protected CreatingElectionFailedException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}