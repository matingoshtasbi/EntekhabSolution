using EntekhabSalaryCalc.Application.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MaritalStatus
{
    public interface IMaritalStatusRepositoryEM : IRepository<MaritalStatusEM , long>
    {
    }
}
