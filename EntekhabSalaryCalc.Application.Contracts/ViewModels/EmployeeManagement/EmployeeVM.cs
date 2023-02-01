using EntekhabSalaryCalc.Application.Core.Domain;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
         
namespace EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement
{
    public class EmployeeVM:Entity<Guid>
    {
        public string IdNo { get; set; }
        public string Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FathderName { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Birthdate { get; set; }
        public string Birthplace { get; set; }
        public GenderEnum Gender { get; set; }
        public string Nationality { get; set; }
        public MaritalStatusEnum MaritalStatus { get; set; }
        public MilitaryServiceStatusEnum MilitaryServiceStatus { get; set; }
        public int NumberOfDependents { get; set; }
        public List<EmployeeContactVM> Contacts { get; set; } = new List<EmployeeContactVM>();
        public List<EmployeeEducationVM> Educations { get; set; } = new List<EmployeeEducationVM>();
        public List<EmployeePhysicalInfoVM> PhysicalInfos { get; set; } = new List<EmployeePhysicalInfoVM>();
        public long InsuranceId { get; set; }
        public string InsuranceNo { get; set; }
        public string InsuranceTitle { get; set; }
        public long SupplementaryInsuranceId { get; set; }
        public string SupplementaryInsuranceNo { get; set; }
        public string SupplementaryInsuranceTitle { get; set; }


    }
}
