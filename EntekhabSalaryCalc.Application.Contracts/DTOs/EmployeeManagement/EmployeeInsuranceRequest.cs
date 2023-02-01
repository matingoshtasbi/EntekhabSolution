using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement
{
    public class EmployeeInsuranceRequest
    {
        public long Id { get; set; }
        public long InsuranceId { get; set; }
        public string InsuranceNo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
