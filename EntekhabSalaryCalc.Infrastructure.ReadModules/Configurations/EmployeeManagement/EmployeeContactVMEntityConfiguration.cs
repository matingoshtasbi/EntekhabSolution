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
    internal class EmployeeContactVMEntityConfiguration : IEntityTypeConfiguration<EmployeeContactVM>
    {
        public void Configure(EntityTypeBuilder<EmployeeContactVM> builder)
        {
            builder.ToTable("EmployeeContacts");
        }
    }
}