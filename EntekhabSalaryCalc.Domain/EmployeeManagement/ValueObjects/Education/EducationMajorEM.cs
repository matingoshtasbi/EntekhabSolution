using EntekhabSalaryCalc.Application.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education
{
    public class EducationMajorEM : Entity<long>
    {
        #region properties
        public string Title { get; set; }
        #endregion
    }
}
