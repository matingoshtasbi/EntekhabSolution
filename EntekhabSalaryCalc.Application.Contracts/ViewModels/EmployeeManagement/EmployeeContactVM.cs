using EntekhabSalaryCalc.Application.Core.Domain;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement
{
    public class EmployeeContactVM : Entity<long>
    {
        public string Title { get; set; } = default!;
        public Guid EmployeeId { get; set; } = default!;
        public ContactTypeEnum Type { get; set; } = default!;
        public string Value { get; set; } = default!;
    }
}
