using EntekhabSalaryCalc.Application.Core.Domain;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Localization;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ParameterObjects;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Services;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates
{
    public class Employee : Entity<Guid>
    {
        #region members
        string _idNo = default!;
        string _code = default!;
        string _firstName = default!;
        string _lastName = default!;
        string? _fatherName = default!;
        DateTime _employmentDate = default!;
        DateTime? _releaseDate = default!;
        DateTime _birthdate = default!;
        string _birthplace = default!;
        long _gender = default!;
        string _nationality = default!;
        long? _insuranceId = default!;
        string? _insuranceNo = default!;
        long? _supplementaryInsuranceId = default!;
        string? _supplementaryInsuranceNo = default!;
        long _maritalStatusId = default!;
        long _militaryServiceStatusId = default!;
        int _numberOfDependents = default!;
        List<EmployeeContact> _contacts = new List<EmployeeContact>();
        List<EmployeeEducation> _educations = new List<EmployeeEducation>();
        List<EmployeePhysicalInfo> _physicalInfo = new List<EmployeePhysicalInfo>();

        #endregion members

        #region constractors
        public Employee()
        {

        }
        public Employee(EmployeePO po, IEmployeeService employeeService)
        {
            EmployeeService = employeeService;

            validate(po);
            IdNo = po.IdNo;
            Code = po.Code;
            FirstName = po.FirstName;
            LastName = po.LastName;
            MaritalStatusId = po.MaritalStatusId;
            FatherName = po.FatherName;
            EmploymentDate = po.EmploymentDate;
            ReleaseDate = po.ReleaseDate;
            Birthdate = po.Birthdate;
            Birthplace = po.Birthplace;
            GenderId = po.GenderId;
            Nationality = po.Nationality;
            NumberOfDependents = po.NumberOfDependents;
            InsuranceId = po.InsuranceId;
            InsuranceNo = po.InsuranceNo;
            SupplementaryInsuranceId = po.SupplementaryInsuranceId;
            SupplementaryInsuranceNo = po.SupplementaryInsuranceNo;
        }


        #endregion

        #region private methodes
        private void validate(EmployeePO po)
        {
            if (string.IsNullOrEmpty(po.IdNo))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.NationalNo });
            if (string.IsNullOrEmpty(po.Code))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.PersonalCode });
            if (string.IsNullOrEmpty(po.FirstName))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.Firstname });
            if (string.IsNullOrEmpty(po.LastName))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.Lastname });
            if (EmployeeService.IsEmployeeIdNoExist(po.IdNo , Id))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldAlreadExist, new string[] { EmployeeManagementLocalization.NationalNo , po.IdNo });
            if (EmployeeService.IsEmployeeCodeExist(po.Code , Id))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldAlreadExist, new string[] { EmployeeManagementLocalization.PersonalCode, po.Code });
            if (po.GenderId != 0 && !EmployeeService.IsGenderInvalid(po.GenderId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.Gender });
            if (po.MaritalStatusId != 0 && !EmployeeService.IsMaritalStatusInvalid(po.MaritalStatusId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.MaritalStatus });
            if (po.MilitaryServiceStatusId != 0 && !EmployeeService.IsMilitaryServiceStatusInvalid(po.MilitaryServiceStatusId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.MilitaryServiceStatus });
            if (po.EmploymentDate < po.Birthdate)
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.CannotBiggerThan, new string[] { EmployeeManagementLocalization.Birthdate , EmployeeManagementLocalization.EmploymentDate });
            if (po.ReleaseDate < po.EmploymentDate)
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.CannotBiggerThan, new string[] { EmployeeManagementLocalization.ReleaseDate, EmployeeManagementLocalization.EmploymentDate });
            if (po.InsuranceId != 0 && !EmployeeService.IsInsuranceValid(po.InsuranceId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound , new string[] { EmployeeManagementLocalization.Insurance });
            if (po.SupplementaryInsuranceId != 0 && !EmployeeService.IsSupplementaryInsuranceInvalid(po.SupplementaryInsuranceId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.SupplementaryInsurance });

        }
        private EmployeeContact? findContact(long contactId)
        {
            var employeeContact = Contacts.FirstOrDefault(c => c.Id == contactId);
            if (employeeContact == null)
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.EmployeeContact });

            return employeeContact;
        }
        private EmployeeEducation findEducation(long educationId)
        {
            var employeeEducation = Educations.FirstOrDefault(c => c.Id == educationId);
            if (employeeEducation == null)
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.EmployeeEducation });

            return employeeEducation;
        }
        private EmployeePhysicalInfo findPhysicalInfo(long physicalInfoId)
        {
            var employeePhysicalInfo = PhysicalInfo.FirstOrDefault(c => c.Id == physicalInfoId);
            if (employeePhysicalInfo == null)
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.EmployeePhysicalInfo });

            return employeePhysicalInfo;
        }

        #endregion

        #region properties
        public string IdNo { get => _idNo; set => _idNo = value; }
        public string Code { get => _code; set => _code = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string? FatherName { get => _fatherName; set => _fatherName = value; }
        public DateTime EmploymentDate { get => _employmentDate; set => _employmentDate = value; }
        public long? InsuranceId { get => _insuranceId; set => _insuranceId = value; }
        public string? InsuranceNo { get => _insuranceNo; set => _insuranceNo = value; }
        public long? SupplementaryInsuranceId { get => _supplementaryInsuranceId; set => _supplementaryInsuranceId = value; }
        public string? SupplementaryInsuranceNo { get => _supplementaryInsuranceNo; set => _supplementaryInsuranceNo = value; }

        public DateTime? ReleaseDate { get => _releaseDate; set => _releaseDate = value; }
        public DateTime Birthdate { get => _birthdate; set => _birthdate = value; }
        public string Birthplace { get => _birthplace; set => _birthplace = value; }
        public long GenderId { get => _gender; set => _gender = value; }
        public string Nationality { get => _nationality; set => _nationality = value; }
        public long MaritalStatusId { get => _maritalStatusId; set => _maritalStatusId = value; }
        public long MilitaryServiceStatusId { get => _militaryServiceStatusId; set => _militaryServiceStatusId = value; }
        public int NumberOfDependents { get => _numberOfDependents; set => _numberOfDependents = value; }
        public virtual List<EmployeeContact> Contacts { get => _contacts; set => _contacts = value; }
        public virtual List<EmployeeEducation> Educations { get => _educations; set => _educations = value; }
        public virtual List<EmployeePhysicalInfo> PhysicalInfo { get => _physicalInfo; set => _physicalInfo = value; }

        public IEmployeeService EmployeeService = default!;
        #endregion

        #region public methodes

        #region employee PO
        public void UpdateProperties(EmployeePO po)
        {
            validate(po);
            IdNo = po.IdNo;
            Code = po.Code;
            FirstName = po.FirstName;
            LastName = po.LastName;
            MaritalStatusId = po.MaritalStatusId;
            MilitaryServiceStatusId = po.MilitaryServiceStatusId;
            FatherName = po.FatherName;
            EmploymentDate = po.EmploymentDate;
            ReleaseDate = po.ReleaseDate;
            Birthdate = po.Birthdate;
            Birthplace = po.Birthplace;
            GenderId = po.GenderId;
            Nationality = po.Nationality;
            NumberOfDependents = po.NumberOfDependents;
            InsuranceId = po.InsuranceId;
            InsuranceNo = po.InsuranceNo;
            SupplementaryInsuranceId = po.SupplementaryInsuranceId;
            SupplementaryInsuranceNo = po.SupplementaryInsuranceNo;
        }
        #endregion

        #region contact
        public EmployeeContact AddContact(string title, ContactTypeEnum type, string value)
        {
            var employeeContact = EmployeeFactory.CreateContact(title, type, value);
            Contacts.Add(employeeContact);
            if (Contacts.GroupBy(c => new { c.Title , c.Value , c.Type})
              .Where(p => p.Count() > 1).Any())
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.IsRepeatedRecord, new string[] { EmployeeManagementLocalization.EmployeeContact });
            return employeeContact;
        }
        public void UpdateContact(long contactId, string title, ContactTypeEnum type, string value)
        {
            var employeeContact = findContact(contactId);
            employeeContact.UpdateProperties(title, type, value);
            if (Contacts.GroupBy(c => new { c.Title, c.Value, c.Type })
              .Where(p => p.Count() > 1).Any())
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.IsRepeatedRecord, new string[] { EmployeeManagementLocalization.EmployeeContact });
        }
        public void RemoveContact(long contactId)
        {
            var employeeContact = findContact(contactId);
            Contacts.Remove(employeeContact);
        }
        #endregion

        #region Education
        public EmployeeEducation AddEducation(long levelId, long majorId, string minor, int average)
        {
            if (!EmployeeService.IsEducationLevelValid(levelId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.EducationLevel });
            if (!EmployeeService.IsEducationMajorValid(levelId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.EducationMajor });
            var employeeEducation = EmployeeFactory.CreateEducation(levelId, majorId, minor, average);
            Educations.Add(employeeEducation);
            if (Educations.GroupBy(e => new { e.LevelId, e.MajorId, e.Minor })
                .Where(e => e.Count() > 1).Any())
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.IsRepeatedRecord, new string[] { EmployeeManagementLocalization.EmployeeEducation });
            return employeeEducation;
        }
        public void UpdateEducation(long educationId, long levelId, long majorId, string minor, int average)
        {
            if (!EmployeeService.IsEducationLevelValid(levelId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.EducationLevel });
            if (!EmployeeService.IsEducationMajorValid(levelId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.EducationMajor });
            var employeeEducation = findEducation(educationId);
            employeeEducation.UpdateProperties(levelId, majorId, minor, average);
            if (Educations.GroupBy(e => new { e.LevelId, e.MajorId, e.Minor })
               .Where(e => e.Count() > 1).Any())
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.IsRepeatedRecord, new string[] { EmployeeManagementLocalization.EmployeeEducation });
        }
        public void RemoveEducation(long educationId)
        {
            var employeeEducation = findEducation(educationId);
            Educations.Remove(employeeEducation);
        }
        #endregion

        #region physicalInfo
        public EmployeePhysicalInfo AddPhysicalInfo(long physicalInfoId, string value)
        {
            if (!EmployeeService.IsPhysicalInfoValid(physicalInfoId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.PhysicalInfo });
            var employeePhysicalInfo = EmployeeFactory.CreatePhysicalInfo(physicalInfoId, value);
            PhysicalInfo.Add(employeePhysicalInfo);
            if (PhysicalInfo.GroupBy(p => new { p.PhysicalInfoId })
               .Where(p => p.Count() > 1).Any())
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.IsRepeatedRecord, new string[] { EmployeeManagementLocalization.EmployeePhysicalInfo });
            return employeePhysicalInfo;
        }
        public void UpdatePhysicalInfo(long id , long physicalInfoId, string value)
        {
            if (!EmployeeService.IsPhysicalInfoValid(physicalInfoId))
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.PhysicalInfo });
            var employeePhysicalInfo = findPhysicalInfo(id);
            employeePhysicalInfo.UpdateProperties(physicalInfoId, value);
            if (PhysicalInfo.GroupBy(p => new { p.PhysicalInfoId })
               .Where(p => p.Count() > 1).Any())
                throw new InvalidEmployeeValueException(EmployeeManagementLocalization.IsRepeatedRecord, new string[] { EmployeeManagementLocalization.EmployeePhysicalInfo });
        }
        public void RemovePhysicalInfo(long physicalInfoId)
        {
            var employeePhysicalInfo = findPhysicalInfo(physicalInfoId);
            PhysicalInfo.Remove(employeePhysicalInfo);
        }
        #endregion

        #endregion
    }
}
