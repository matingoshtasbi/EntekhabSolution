using EntekhabSalaryCalc.Application.Contracts.Abstractions.EmployeeManagement;
using EntekhabSalaryCalc.Application.Services.EmployeeManagement;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Services;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Gender;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using EntekhabSalaryCalc.Infrastructure.Persistence.Repositories.EmployeeManagement;
using EntekhabSalaryCalc.Infrastructure.ReadModules.Repositories.EmployeeManagement;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.DependencyInjectionExtensions
{
    public static class EmployeeManagementExtension
    {
        public static IServiceCollection AddEmployeeManagementModules(this IServiceCollection services)
        {
            services.AddTransient<IEmployeeCommandService, EmployeeCommandService>();
            services.AddTransient<IEmployeeQueryService, EmployeeQueryService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeManagementReadRepository, EmployeeManagementReadRepository>();
            services.AddTransient<IEducationLevelRepositoryEM, EducationLevelRepositoryEM>();
            services.AddTransient<IEducationMajorRepositoryEM, EducationMajorRepositoryEM>();
            services.AddTransient<IPhysicalInfoRepositoryEM, PhysicalInfoRepositoryEM>();
            services.AddTransient<IInsuranceRepositoryEM, InsuranceRepositoryEM>();
            services.AddTransient<ISupplementaryInsuranceRepositoryEM, SupplementaryInsuranceRepositoryEM>();
            services.AddTransient<IMaritalStatusRepositoryEM, MaritalStatusRepositoryEM>();
            services.AddTransient<IGenderRepositoryEM, GenderRepositoryEM>();
            services.AddTransient<IMilitaryServiceStatusRepositoryEM, MilitaryServiceStatusRepositoryEM>();
            services.AddTransient<IEmployeeService, EmployeeService>();



            return services;
        }
    }
}
