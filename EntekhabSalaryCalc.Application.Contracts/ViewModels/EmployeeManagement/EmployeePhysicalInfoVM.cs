using EntekhabSalaryCalc.Application.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement
{
    public class EmployeePhysicalInfoVM : Entity<long>
    {
        public Guid EmployeeId { get; set; } = default!;
        public string Title { get; set; }
        public string Value { get; set; }
    }
}
