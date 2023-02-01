using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Gender;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using EntekhabSalaryCalc.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.Persistence.DbContexts
{
    public class CommandDbContext : DbContext
    {
        #region constractor
        public CommandDbContext(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region properties

        #region employee management 
        public DbSet<Employee> Employees { get; set; } = default!;
        public DbSet<EducationLevelEM> EMEducationLevels { get; set; } = default!;
        public DbSet<EducationMajorEM> EMEducationMajors { get; set; } = default!;
        public DbSet<PhysicalInfoEM> EMPhysicalInfos { get; set; } = default!;
        public DbSet<InsuranceEM> EMInsurances { get; set; } = default!;
        public DbSet<SupplementaryInsuranceEM> EMSupplementaryInsurances { get; set; } = default!;
        public DbSet<MaritalStatusEM> EMMaritalStatuses { get; set; } = default!;
        public DbSet<GenderEM> EMGenders { get; set; } = default!;
        public DbSet<MilitaryServiceStatusEM> EMMilitaryServiceStatuses { get; set; } = default!;
        #endregion

        #endregion

        #region protected methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommandDbContext).Assembly);
        }
        #endregion
    }
}
