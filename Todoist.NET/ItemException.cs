// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ItemException.cs" company="Jakob Pedersen">
//   Copyright (c) Jakob Pedersen
// </copyright>
// <summary>
//   A general exception for all item errors.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Todoist.NET
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// A general exception for all item errors.
    /// </summary>
    [Serializable]
    public class ItemException : SystemException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemException"/> class. 
        /// </summary>
        public ItemException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the<see cref="ItemException"/>class.
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        public ItemException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the<see cref="ItemException"/>class.
        /// </summary>
        /// <param name="message">
        /// The error message explaining what went wrong and how to fix it.
        /// </param>
        /// <param name="innerException">
        /// The <see cref="innerException"/> of the error.
        /// </param>
        public ItemException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemException"/> class. 
        /// </summary>
        /// <param name="info">
        /// The <see cref="SerializationInfo"/>.
        /// </param>
        /// <param name="context">
        /// The <see cref="StreamingContext"/>.
        /// </param>
        protected ItemException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}