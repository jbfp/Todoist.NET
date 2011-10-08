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
        /// </param>
        public RegistrationFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationFailedException"/> class. 
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="innerException">
        /// </param>
        public RegistrationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationFailedException"/> class. 
        /// </summary>
        /// <param name="info">
        /// </param>
        /// <param name="context">
        /// </param>
        protected RegistrationFailedException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}