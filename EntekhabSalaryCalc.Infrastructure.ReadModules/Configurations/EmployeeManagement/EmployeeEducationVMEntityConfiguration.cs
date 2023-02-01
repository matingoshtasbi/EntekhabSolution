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
    internal class EmployeeEducationVMEntityConfiguration : IEntityTypeConfiguration<EmployeeEducationVM>
    {
        public void Configure(EntityTypeBuilder<EmployeeEducationVM> builder)
        {
            builder.ToSqlQuery(@"SELECT ee.[Id]
                                  ,ee.[EmployeeId]
	                              ,ee.[LevelId]
                                  ,ee.[MajorId]
                                  ,ee.[Minor]
                                  ,ee.[Average]
	                              ,el.Title LevelTitle
	                              ,el.Value LevelValue
	                              ,em.Title MajorTitle
                              FROM [Test1].[dbo].[EmployeeEducations] ee
                              LEFT JOIN [dbo].[EducationLevels] el on ee.LevelId = el.Id
                              LEFT JOIN [dbo].EducationMajors em on ee.MajorId = em.Id");
            //builder.HasOne(c => c.Level)
            //builder.Property(x => x.).HasMaxLength(100);
        }
    }
}
