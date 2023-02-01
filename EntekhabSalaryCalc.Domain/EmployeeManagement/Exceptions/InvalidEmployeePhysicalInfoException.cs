using EntekhabSalaryCalc.Application.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions
{
    public class InvalidEmployeePhysicalInfoException : DomainException
    {
        public InvalidEmployeePhysicalInfoException(string message) : base(message)
        {
        }
        public InvalidEmployeePhysicalInfoException(string message, string[] parameters) : base(message, parameters)
        {
        }
        public InvalidEmployeePhysicalInfoException(string message, List<DomainExceptionDetail> details) : base(message, details)
        {
        }
        public InvalidEmployeePhysicalInfoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
