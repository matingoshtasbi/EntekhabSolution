using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Gender;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using EntekhabSalaryCalc.Infrastructure.Persistence.Configurations;
using EntekhabSalaryCalc.Infrastructure.Persistence.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.Persistence.SqlServer.DbContexts
{
    public class SqlServerCommandDbContext : CommandDbContext
    {
        #region constractor
        public SqlServerCommandDbContext(DbContextOptions<SqlServerCommandDbContext> options) : base(options)
        {
        }
        #endregion
    }
}

