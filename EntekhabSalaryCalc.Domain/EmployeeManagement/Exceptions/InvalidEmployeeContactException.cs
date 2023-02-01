using EntekhabSalaryCalc.Application.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions
{
    public class InvalidEmployeeContactException : DomainException
    {
        public InvalidEmployeeContactException(string message) : base(message)
        {
        }
        public InvalidEmployeeContactException(string message, string[] parameters) : base(message, parameters)
        {
        }
        public InvalidEmployeeContactException(string message, List<DomainExceptionDetail> details) : base(message, details)
        {
        }
        public InvalidEmployeeContactException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
