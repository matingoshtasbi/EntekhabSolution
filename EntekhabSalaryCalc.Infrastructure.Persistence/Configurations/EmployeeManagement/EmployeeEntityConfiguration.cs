using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.Persistence.Configurations.EmployeeManagement
{
    internal class EmployeeAMEntityConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasMany(c => c.Contacts).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.Educations).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(c => c.PhysicalInfo).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}