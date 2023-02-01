using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.ParameterObjects
{
    public class EmployeePO
    {
        public string IdNo { get; set; } = default!;
        public string Code { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string FatherName { get; set; } = default!;
        public DateTime EmploymentDate { get; set; } = default!;
        public DateTime? ReleaseDate { get; set; } = default!;
        public DateTime Birthdate { get; set; } = default!;
        public string Birthplace { get; set; } = default!;
        public long GenderId { get; set; } = default!;
        public string Nationality { get; set; } = default!;
        public int NumberOfDependents { get; set; } = default!;
        public long MaritalStatusId { get; set; } = default!;
        public long MilitaryServiceStatusId { get; set; } = default!;
        public long InsuranceId { get; set; }
        public string InsuranceNo { get; set; }
        public long SupplementaryInsuranceId { get; set; }
        public string SupplementaryInsuranceNo { get; set; }
    }
}
