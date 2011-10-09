// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegistrationFailedException.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the RegistrationFailedException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception for when registration fails.
    /// </summary>
    [Serializable]
    public class RegistrationFailedException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationFailedException"/> class. 
        /// </summary>
        public RegistrationFailedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationFailedException"/> class. 
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        public RegistrationFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationFailedException"/> class. 
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        /// <param name="innerException">
        /// The <see cref="innerException"/> of the error.
        /// </param>
        public RegistrationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationFailedException"/> class. 
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/>.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>.
        /// </param>
        protected RegistrationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}