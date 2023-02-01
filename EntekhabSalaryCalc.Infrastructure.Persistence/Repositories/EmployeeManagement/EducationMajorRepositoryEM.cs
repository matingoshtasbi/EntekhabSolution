using EntekhabSalaryCalc.Application.Core.Abstractions;
using EntekhabSalaryCalc.Application.Core.Infrastructure;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.Persistence.Repositories.EmployeeManagement
{
    public class EducationMajorRepositoryEM : Repository<EducationMajorEM, long>, IEducationMajorRepositoryEM
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractor
        public EducationMajorRepositoryEM(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion
    }
}
