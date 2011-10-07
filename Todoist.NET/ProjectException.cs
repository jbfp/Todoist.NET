using System;
using System.Runtime.Serialization;

namespace TodoistDotNet
{
    [Serializable]
    public class ProjectException : SystemException
    {
        public ProjectException()
        {
        }

        public ProjectException(string message) : base(message)
        {
        }

        public ProjectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ProjectException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}