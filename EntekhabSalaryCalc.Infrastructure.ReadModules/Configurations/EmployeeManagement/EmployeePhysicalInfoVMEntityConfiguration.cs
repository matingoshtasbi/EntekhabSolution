using EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.ReadModules.Configurations.EmployeeManagement
{
    internal class EmployeePhysicalInfoVMEntityConfiguration : IEntityTypeConfiguration<EmployeePhysicalInfoVM>
    {
        public void Configure(EntityTypeBuilder<EmployeePhysicalInfoVM> builder)
        {
            builder.ToSqlQuery(@"SELECT ep.[Id]
                                ,[PhysicalInfoId]
                                ,[Value]
                                ,[EmployeeId]
	                            ,[pi].Title
                             FROM [Test1].[dbo].[EmployeePhysicalInfos] ep
                             LEFT JOIN [dbo].[PhysicalInfos] [pi] on [pi].Id = ep.PhysicalInfoId");
        }
    }
}
