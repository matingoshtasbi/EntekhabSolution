using EntekhabSalaryCalc.Application.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions
{
    public class InvalidEmployeeValueException : DomainException
    {
        public InvalidEmployeeValueException(string message) : base(message)
        {
        }
        public InvalidEmployeeValueException(string message, string[] parameters) : base(message, parameters)
        {
        }
        public InvalidEmployeeValueException(string message, List<DomainExceptionDetail> details) : base(message, details)
        {
        }
        public InvalidEmployeeValueException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
