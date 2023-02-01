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
    internal class EmployeePhysicalInfoEntityConfiguration : IEntityTypeConfiguration<EmployeePhysicalInfo>
    {

        public void Configure(EntityTypeBuilder<EmployeePhysicalInfo> builder)
        {
            builder.ToTable("EmployeePhysicalInfos");
        }
    }
}