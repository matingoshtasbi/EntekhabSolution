using EntekhabSalaryCalc.Application.Core.Abstractions;
using EntekhabSalaryCalc.Application.Core.DTOs;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.Abstractions.EmployeeManagement
{
    public interface IEmployeeManagementReadRepository
    {
        Task<PageResult<EmployeeVM>> GetEmployees(FindEmployeesRequest request);
        Task<EmployeeVM> GetEmployee(Guid id);
    }
}
