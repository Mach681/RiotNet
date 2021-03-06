﻿using System;
#if NET_45
using System.Runtime.Serialization;
using System.Security.Permissions;
#endif

namespace RiotNet
{
    /// <summary>
    /// Represents an error that occurs when a REST request fails because the rate limit has been exceeded.
    /// </summary>
    public class RateLimitExceededException : RestException
    {
        /// <summary>
        /// Creates a new <see cref="RateLimitExceededException"/> instance.
        /// </summary>
        public RateLimitExceededException()
            : this(null)
        { }

        /// <summary>
        /// Creates a new <see cref="RateLimitExceededException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        public RateLimitExceededException(RiotResponse response)
            : this(response, (Exception)null)
        { }

        /// <summary>
        /// Creates a new <see cref="RateLimitExceededException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RateLimitExceededException(RiotResponse response, Exception innerException)
            : base(response, "The rate limit for the current API key was exceeded.", innerException)
        { }

        /// <summary>
        /// Creates a new <see cref="RateLimitExceededException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        public RateLimitExceededException(RiotResponse response, string message)
            : base(response, message)
        { }

        /// <summary>
        /// Creates a new <see cref="RateLimitExceededException"/> instance.
        /// </summary>
        /// <param name="response">The response.</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public RateLimitExceededException(RiotResponse response, string message, Exception innerException)
            : base(response, message, innerException)
        { }

#if NET_45
        /// <summary>
        /// Creates a new <see cref="RateLimitExceededException"/> instance.
        /// </summary>
        /// <param name="info">The SerializationInfo that holds the serialized object data about the exception.</param>
        /// <param name="context">The StreamingContext that contains contextual information about the source or destination.</param>
        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected RateLimitExceededException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        { }
#endif
    }
}
