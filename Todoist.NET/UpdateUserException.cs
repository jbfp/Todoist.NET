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
        /// </param>
        public UpdateUserException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserException"/> class. 
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="innerException">
        /// </param>
        public UpdateUserException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UpdateUserException"/> class. 
        /// </summary>
        /// <param name="info">
        /// </param>
        /// <param name="context">
        /// </param>
        protected UpdateUserException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}