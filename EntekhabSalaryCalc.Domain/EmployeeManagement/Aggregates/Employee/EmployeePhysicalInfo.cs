using EntekhabSalaryCalc.Application.Core.Domain;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Localization;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates
{
    public class EmployeePhysicalInfo : Entity<long>
    {
        #region constractor
        public EmployeePhysicalInfo()
        {

        }
        public EmployeePhysicalInfo(long physicalInfoId, string value)
        {
            validate(value);
            PhysicalInfoId = physicalInfoId;
            Value = value;
        }
        #endregion

        #region properties
        public long PhysicalInfoId { get; set; }
        public string Value { get; set; }
        #endregion

        #region public methods
        internal void UpdateProperties(long physicalInfoId, string value)
        {
            validate(value);
            PhysicalInfoId = physicalInfoId;
            Value = value;
        }
        #endregion

        #region private methods
        private void validate(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new InvalidEmployeePhysicalInfoException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.PhysicalInfoTitle });
        }
        #endregion
    }
}
