// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProjectException.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   Defines the ProjectException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// An exception for all general project errors.
    /// </summary>
    [Serializable]
    public class ProjectException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectException"/> class. 
        /// </summary>
        public ProjectException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectException"/> class. 
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        public ProjectException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectException"/> class. 
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        /// <param name="innerException">
        /// The <see cref="innerException"/> of the error.
        /// </param>
        public ProjectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectException"/> class. 
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/>.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>.
        /// </param>
        protected ProjectException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}