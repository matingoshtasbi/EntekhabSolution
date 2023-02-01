using AutoMapper;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement.BaseInfo;
using EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ParameterObjects;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Infrastructure.AutoMapper
{
    public class EmployeeManagementProfile : Profile
    {
        public EmployeeManagementProfile()
        {
            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, EmployeeRequest>();
            CreateMap<EmployeeRequest, EmployeePO>();
            CreateMap<EducationLevelEM, EducationLevelDto>();
            CreateMap<EducationMajorEM, EducationMajorDto>();
            CreateMap<PhysicalInfoEM, PhysicalInfoDto>();

        }
    }
}
