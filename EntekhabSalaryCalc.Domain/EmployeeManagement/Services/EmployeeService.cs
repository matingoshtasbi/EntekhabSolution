using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Gender;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MaritalStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.MilitaryServiceStatus;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Services
{
    public class EmployeeService : IEmployeeService
    {
        #region members
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationLevelRepositoryEM _educationLevelRepository;
        private readonly IEducationMajorRepositoryEM _educationMajorRepository;
        private readonly IPhysicalInfoRepositoryEM _physicalInfoRepository;
        private readonly IInsuranceRepositoryEM _insuranceRepository;
        private readonly ISupplementaryInsuranceRepositoryEM _supplementaryInsuranceRepository;
        private readonly IMaritalStatusRepositoryEM _maritalStatusRepository;
        private readonly IGenderRepositoryEM _genderRepository;
        private readonly IMilitaryServiceStatusRepositoryEM _militaryServiceStatusRepository;
        #endregion

        #region constractors
        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IEducationLevelRepositoryEM educationLevelRepository,
            IEducationMajorRepositoryEM educationMajorRepository,
            IPhysicalInfoRepositoryEM physicalInfoRepository,
            IInsuranceRepositoryEM insuranceRepository,
            ISupplementaryInsuranceRepositoryEM supplementaryInsuranceRepository,
            IMaritalStatusRepositoryEM maritalStatusRepository,
            IGenderRepositoryEM genderRepository,
            IMilitaryServiceStatusRepositoryEM militaryServiceStatusRepository)
        {
            _employeeRepository = employeeRepository;
            _educationLevelRepository = educationLevelRepository;
            _educationMajorRepository = educationMajorRepository;
            _physicalInfoRepository = physicalInfoRepository;
            _insuranceRepository = insuranceRepository;
            _supplementaryInsuranceRepository = supplementaryInsuranceRepository;
            _maritalStatusRepository = maritalStatusRepository;
            _genderRepository = genderRepository;
            _militaryServiceStatusRepository = militaryServiceStatusRepository;
        }
        #endregion

        #region public methods
        public bool IsEmployeeIdNoExist(string idNo, Guid exceptId)
        {
            return _employeeRepository.Get(c => c.IdNo == idNo && c.Id != exceptId).Any();
        }
        public bool IsEmployeeCodeExist(string code, Guid exceptId)
        {
            return _employeeRepository.Get(c => c.Code == code && c.Id != exceptId).Any();
        }
        public bool IsEducationLevelValid(long levelId)
        {
            return _educationLevelRepository.Get(el => el.Id == levelId).Any();
        }
        public bool IsEducationMajorValid(long majorId)
        {
            return _educationMajorRepository.Get(em => em.Id == majorId).Any();
        }
        public bool IsPhysicalInfoValid(long physicalInfoId)
        {
            return _physicalInfoRepository.Get(em => em.Id == physicalInfoId).Any();
        }
        public bool IsInsuranceValid(long insuranceId)
        {
            return _insuranceRepository.Get(c => c.Id == insuranceId).Any();
        }
        public bool IsSupplementaryInsuranceInvalid(long supplementaryInsuranceId)
        {
            return _supplementaryInsuranceRepository.Get(c => c.Id == supplementaryInsuranceId).Any();
        }
        public bool IsMaritalStatusInvalid(long maritalStatusId)
        {
            return _maritalStatusRepository.Get(c => c.Id == maritalStatusId).Any();
        }
        public bool IsGenderInvalid(long genderId)
        {
            return _genderRepository.Get(c => c.Id == genderId).Any();
        }

        public bool IsMilitaryServiceStatusInvalid(long militaryServiceStatusId)
        {
            return _militaryServiceStatusRepository.Get(c => c.Id == militaryServiceStatusId).Any();
        }


        #endregion
    }
}
