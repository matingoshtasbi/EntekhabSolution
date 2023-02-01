using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement
{
    public class EmployeeRequest
    {
        public Guid? Id { get; set; }
        public string IdNo { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }
        public GenderEnum Gender { get; set; }
        public string Nationality { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public MilitaryServiceStatusEnum MilitaryServiceStatus { get; set; }
        public int NumberOfDependents { get; set; }
        public List<EmployeeContactRequest> Contacts { get; set; } = new List<EmployeeContactRequest>();
        public List<EmployeeEducationRequest> Educations { get; set; } = new List<EmployeeEducationRequest>();
        public List<EmployeePhysicalInfoRequest> PhysicalInfo { get; set; } = new List<EmployeePhysicalInfoRequest>();
        public long? InsuranceId { get; set; }
        public string? InsuranceNo { get; set; }
        public long? SupplementaryInsuranceId { get; set; }
        public string? SupplementaryInsuranceNo { get; set; }
    }
}
