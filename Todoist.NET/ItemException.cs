using System;
using System.Runtime.Serialization;

namespace TodoistDotNet
{
    [Serializable]
    public class ItemException : SystemException
    {
        public ItemException()
        {
        }

        public ItemException(string message)
            : base(message)
        {
        }

        public ItemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ItemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}