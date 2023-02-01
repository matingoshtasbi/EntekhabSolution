using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Services
{
    public interface IEmployeeService
    {
        bool IsEmployeeIdNoExist(string idNo , Guid exceptId);
        bool IsEmployeeCodeExist(string code , Guid exceptId);
        bool IsInsuranceValid(long insuranceId);
        bool IsSupplementaryInsuranceInvalid(long supplementaryInsuranceId);
        bool IsEducationLevelValid(long levelId);
        bool IsEducationMajorValid(long majorId);
        bool IsPhysicalInfoValid(long physicalInfoId);
        bool IsMaritalStatusInvalid(long maritalStatusId);
        bool IsGenderInvalid(long maritalStatusId);
        bool IsMilitaryServiceStatusInvalid(long militaryServiceStatusId);
    }
}
