using System;
using System.Runtime.Serialization;

namespace TodoistDotNet
{
    [Serializable]
    public class UpdateUserException : SystemException
    {
        public UpdateUserException()
        {
        }

        public UpdateUserException(string message) : base(message)
        {
        }

        public UpdateUserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UpdateUserException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}