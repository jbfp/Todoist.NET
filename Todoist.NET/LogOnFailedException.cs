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
    /// The LogOn failed exception.
    /// </summary>
    [Serializable]
    public class LogOnFailedException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LogOnFailedException"/> class. 
        /// </summary>
        public LogOnFailedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogOnFailedException"/> class. 
        /// The LogOn failed exception.
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        public LogOnFailedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogOnFailedException"/> class. 
        /// The LogOn failed exception.
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        /// <param name="innerException">
        /// The <see cref="innerException"/> of the error.
        /// </param>
        public LogOnFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogOnFailedException"/> class. 
        /// The LogOn failed exception.
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/>.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>.
        /// </param>
        protected LogOnFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}