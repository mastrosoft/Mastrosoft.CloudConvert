using Mastrosoft.CloudConvert.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mastrosoft.CloudConvert
{
    [Serializable]
    internal class CloudConvertException : Exception
    {
        public CloudConvertException()
        {
        }

        public CloudConvertException(ErrorResponse errorResponse):this("An error occured when converting: " + errorResponse.Message)
        {
            this.Code = errorResponse.Code;
            this.Errors = errorResponse.Errors;
        }

        public CloudConvertException(string message) : base(message)
        {
        }

        public CloudConvertException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CloudConvertException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public string Code { get; }
        public IDictionary<string,string[]> Errors { get; }
    }
}