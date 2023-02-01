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
    internal class EmployeeContactEntityConfiguration : IEntityTypeConfiguration<EmployeeContact>
    {

        public void Configure(EntityTypeBuilder<EmployeeContact> builder)
        {
            builder.ToTable("EmployeeContacts");
            //builder.Property(x => x.).HasMaxLength(100);
        }
    }
}