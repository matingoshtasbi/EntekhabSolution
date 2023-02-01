using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement
{
    public class EmployeeContactRequest
    {
        public long Id { get; set; } = default!;
        public string Title { get; set; } = default!;
        public ContactTypeEnum Type { get; set; } = default!;
        public string Value { get; set; } = default!;
        public bool IsDeleted { get; set; } = default!;
    }
}
