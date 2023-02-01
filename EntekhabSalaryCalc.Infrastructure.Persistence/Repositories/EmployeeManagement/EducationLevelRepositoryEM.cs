using EntekhabSalaryCalc.Application.Core.Abstractions;
using EntekhabSalaryCalc.Application.Core.Infrastructure;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.Persistence.Repositories.EmployeeManagement
{
    public class EducationLevelRepositoryEM : Repository<EducationLevelEM, long>, IEducationLevelRepositoryEM
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constracors
        public EducationLevelRepositoryEM(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion
    }
}
