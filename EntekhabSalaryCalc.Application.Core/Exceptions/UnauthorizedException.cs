using System;
using System.Runtime.Serialization;
using System.Security;

namespace EntekhabSalaryCalc.Application.Core.Exceptions
{
    public class UnAuthorizedException : SecurityException
    {
        public UnAuthorizedException()
        {
        }

        public UnAuthorizedException(string message) : base(message)
        {
        }

        public UnAuthorizedException(string message, Exception inner) : base(message, inner)
        {
        }

        public UnAuthorizedException(string message, Type type) : base(message, type)
        {
        }

        public UnAuthorizedException(string message, Type type, string state) : base(message, type, state)
        {
        }

        protected UnAuthorizedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}