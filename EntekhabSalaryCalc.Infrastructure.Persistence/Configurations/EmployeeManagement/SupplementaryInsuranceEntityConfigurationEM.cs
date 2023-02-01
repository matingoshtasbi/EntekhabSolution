using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.Persistence.Configurations.EmployeeManagement
{
    internal class SupplementaryInsuranceEntityConfigurationEM : IEntityTypeConfiguration<SupplementaryInsuranceEM>
    {

        public void Configure(EntityTypeBuilder<SupplementaryInsuranceEM> builder)
        {
            builder.ToTable(null, el => el.ExcludeFromMigrations());
            builder.ToSqlQuery("select * from SupplementaryInsurances");
        }
    }
}