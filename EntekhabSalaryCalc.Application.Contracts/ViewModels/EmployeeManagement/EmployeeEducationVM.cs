using EntekhabSalaryCalc.Application.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement
{
    public class EmployeeEducationVM : Entity<long>
    {
        public Guid EmployeeId { get; set; } = default!;
        public long LevelId { get; set; }
        public string LevelTitle { get; set; }
        public int LevelValue { get; set; }
        public long MajorId { get; set; }
        public string MajorTitle { get; set; }
        public string Minor { get; set; }
        public int Average { get; set; }
    }
}
