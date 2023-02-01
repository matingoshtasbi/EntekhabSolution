using EntekhabSalaryCalc.Application.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions
{
    public class InvalidEmployeeEducationException : DomainException
    {
        public InvalidEmployeeEducationException(string message) : base(message)
        {
        }
        public InvalidEmployeeEducationException(string message, string[] parameters) : base(message, parameters)
        {
        }
        public InvalidEmployeeEducationException(string message, List<DomainExceptionDetail> details) : base(message, details)
        {
        }
        public InvalidEmployeeEducationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
