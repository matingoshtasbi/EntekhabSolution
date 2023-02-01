using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement.BaseInfo
{
    public class EmployeeBaseInfo
    {
        public List<EducationLevelDto> EducationLevels { get; set; } = new List<EducationLevelDto>();   
        public List<EducationMajorDto> EducationMajors { get; set; } = new List<EducationMajorDto>();
        public List<PhysicalInfoDto> PhysicalInfos { get; set; } = new List<PhysicalInfoDto>();

    }
}
