using EntekhabSalaryCalc.Application.Core.Domain;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance
{
    public class InsuranceEM : Entity<long>
    {
        #region properties
        public string Title { get; set; }
        #endregion
    }
}
