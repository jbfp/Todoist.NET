// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UpdateUserException.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the UpdateUserException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception for when updating the user fails.
    /// </summary>
    [Serializable]
    public class UpdateUserException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserException"/> class. 
        /// </summary>
        public UpdateUserException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserException"/> class. 
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        public UpdateUserException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserException"/> class. 
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        /// <param name="innerException">
        /// The <see cref="innerException"/> of the error.
        /// </param>
        public UpdateUserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserException"/> class. 
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/>.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>.
        /// </param>
        protected UpdateUserException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}