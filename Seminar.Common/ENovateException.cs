using Seminar.Common;
using System;

namespace Seminar
{
    [Serializable]
    public class ENovateException : Exception
    {
        public ENovateException() { }
        public ENovateException(ErrorCodes errorCode, string message):base(message)
        {
            ErrorCode = errorCode;
        }
        public ENovateException(ErrorCodes errorCode)
        {
            ErrorCode = errorCode;
        }

        public ENovateException(string message) : base(message) { }
        public ENovateException(string message, Exception inner) : base(message, inner) { }
        protected ENovateException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public ErrorCodes ErrorCode { get; set; }
    }
}
