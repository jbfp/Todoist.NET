using System;
using System.Runtime.Serialization;

namespace TodoistDotNet
{
    [Serializable]
    public class LoginFailedException : SystemException
    {
        public LoginFailedException()
        {
        }

        public LoginFailedException(string message) : base(message)
        {
        }

        public LoginFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected LoginFailedException(SerializationInfo info, StreamingContext context)
            : base (info, context)
        {
        }
    }
}