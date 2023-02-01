using System;
using System.Runtime.Serialization;

namespace EntekhabSalaryCalc.Application.Core.Exceptions
{
    public class AccessDeniedException : UnAuthorizedException
    {
        public AccessDeniedException()
        {
        }

        public AccessDeniedException(string message) : base(message)
        {
        }

        public AccessDeniedException(string message, Exception inner) : base(message, inner)
        {
        }

        public AccessDeniedException(string message, Type type) : base(message, type)
        {
        }

        public AccessDeniedException(string message, Type type, string state) : base(message, type, state)
        {
        }

        protected AccessDeniedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}