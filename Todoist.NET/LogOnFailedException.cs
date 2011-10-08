// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LogOnFailedException.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the LogOnFailedException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class LogOnFailedException : SystemException
    {
        /// <summary>
        /// 
        /// </summary>
        public LogOnFailedException()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public LogOnFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public LogOnFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected LogOnFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}