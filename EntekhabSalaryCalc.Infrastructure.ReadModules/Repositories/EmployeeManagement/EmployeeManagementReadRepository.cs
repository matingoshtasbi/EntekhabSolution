using EntekhabSalaryCalc.Application.Core.DTOs;
using EntekhabSalaryCalc.Application.Core.Infrastructure;
using EntekhabSalaryCalc.Application.Contracts.Abstractions.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement;
using EntekhabSalaryCalc.Infrastructure.ReadModules.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.ReadModules.Repositories.EmployeeManagement
{
    public class EmployeeManagementReadRepository : IEmployeeManagementReadRepository
    {
        #region members
        private QueryDbContext _dbContext;
        #endregion

        #region constractors
        public EmployeeManagementReadRepository(QueryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion

        #region public methods
        public async Task<EmployeeVM> GetEmployee(Guid id)
        {
            var result = await _dbContext.Employees
                .Include(nameof(EmployeeVM.Contacts))
                .Include(nameof(EmployeeVM.Educations))
                .Include(nameof(EmployeeVM.PhysicalInfos))
                .FirstOrDefaultAsync(c => c.Id == id) ?? null!;

            return result;
        }

        public async Task<PageResult<EmployeeVM>> GetEmployees(FindEmployeesRequest request)
        {
            var result = new PageResult<EmployeeVM>();
            result.PageIndex = request.PageIndex;
            result.PageSize = request.PageSize;

            var qry = _dbContext.Employees.AsNoTracking();
            //qry = qry.OrderBy(x => x.Id);
            //qry.filter

            result.TotalCount = await qry.CountAsync();

            qry = qry.Skip((request.PageIndex - 1) * request.PageSize);

            result.Results = await qry.Take(request.PageSize).ToListAsync();

            return result;
        }
        #endregion
    }
}
