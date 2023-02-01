using EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.ReadModules.Configurations.EmployeeManagement
{
    internal class EmployeeVMEntityConfiguration : IEntityTypeConfiguration<EmployeeVM>
    {
        public void Configure(EntityTypeBuilder<EmployeeVM> builder)
        {
            builder.ToSqlQuery(@"SELECT e.* , I.Title InsuranceTitle , si.Title SupplementaryInsuranceTitle
                                 FROM Employees e
                                 LEFT JOIN Insurances i ON e.InsuranceId = i.Id
                                 LEFT JOIN SupplementaryInsurances si ON e.SupplementaryInsuranceId = si.Id");
            builder.HasMany(c => c.Contacts).WithOne().HasForeignKey(c => c.EmployeeId);
            builder.HasMany(c => c.Educations).WithOne().HasForeignKey(c => c.EmployeeId);
            builder.HasMany(c => c.PhysicalInfos).WithOne().HasForeignKey(c => c.EmployeeId);
        }
    }
}