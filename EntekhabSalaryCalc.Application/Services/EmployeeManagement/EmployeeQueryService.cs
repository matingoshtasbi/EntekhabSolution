using EntekhabSalaryCalc.Application.Core.DTOs;
using EntekhabSalaryCalc.Application.Contracts.Abstractions.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Services.EmployeeManagement
{
    public class EmployeeQueryService : IEmployeeQueryService
    {
        #region members
        private IEmployeeManagementReadRepository _employeeManagementReadRepository;
        #endregion

        #region constractors
        public EmployeeQueryService(IEmployeeManagementReadRepository employeeReadRepository)
        {
            _employeeManagementReadRepository = employeeReadRepository;
        }
        #endregion

        #region public methods
        public async Task<PageResult<EmployeeVM>> FindEmployees(FindEmployeesRequest request)
        {
            return await _employeeManagementReadRepository.GetEmployees(request);
        }
        public async Task<EmployeeVM> FindEmployee(Guid id)
        {
            return await _employeeManagementReadRepository.GetEmployee(id);
        }
        #endregion
    }
}
