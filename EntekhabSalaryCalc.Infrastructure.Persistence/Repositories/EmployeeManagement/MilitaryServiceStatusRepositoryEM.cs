using EntekhabSalaryCalc.Application.Core.Abstractions;
using EntekhabSalaryCalc.Application.Core.Infrastructure;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Gender;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EntekhabSalaryCalc.Infrastructure.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.Persistence.Repositories.EmployeeManagement
{
    public class MilitaryServiceStatusRepositoryEM : Repository<MilitaryServiceStatusEM, long>, IMilitaryServiceStatusRepositoryEM
    {
        #region members
        private CommandDbContext _dbContext = default!;
        #endregion

        #region constractor
        public MilitaryServiceStatusRepositoryEM(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _dbContext = unitOfWork.DbContext as CommandDbContext;
        }
        #endregion
    }
}
