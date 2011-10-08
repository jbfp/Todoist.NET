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
        /// </param>
        public ProjectException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectException"/> class. 
        /// </summary>
        /// <param name="message">
        /// </param>
        /// <param name="innerException">
        /// </param>
        public ProjectException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ProjectException"/> class. 
        /// </summary>
        /// <param name="info">
        /// </param>
        /// <param name="context">
        /// </param>
        protected ProjectException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}