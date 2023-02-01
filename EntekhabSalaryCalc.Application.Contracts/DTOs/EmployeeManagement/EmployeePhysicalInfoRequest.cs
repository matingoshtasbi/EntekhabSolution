using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement
{
    public class EmployeePhysicalInfoRequest
    {
        public long Id { get; set; }
        public long PhysicalInfoId { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
