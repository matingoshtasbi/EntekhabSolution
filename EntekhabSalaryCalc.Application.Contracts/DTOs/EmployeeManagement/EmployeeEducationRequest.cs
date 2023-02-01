using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement
{
    public class EmployeeEducationRequest
    {
        public long Id { get; set; }
        public long LevelId { get; set; }
        public long MajorId { get; set; }
        public string Minor { get; set; }
        public int Average { get; set; }
        public bool IsDeleted { get; set; }

    }
}
