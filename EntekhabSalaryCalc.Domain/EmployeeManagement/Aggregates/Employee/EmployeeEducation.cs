using EntekhabSalaryCalc.Application.Core.Domain;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Localization;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates
{
    public class EmployeeEducation: Entity<long>
    {
        #region constractors
        public EmployeeEducation()
        {

        }
        public EmployeeEducation(long levelId, long majorId, string minor, int average)
        {
            validate(minor , average);
            LevelId = levelId;
            MajorId = majorId;
            Minor = minor;
            Average = average;
        }
        #endregion

        #region properties

        public long LevelId { get; set; }
        public long MajorId { get; set; }
        public string Minor { get; set; }
        public int Average { get; set; }
        #endregion

        #region public methods
        internal void UpdateProperties(long levelId, long majorId, string minor, int average)
        {
            validate(minor, average);
            LevelId = levelId;
            MajorId = majorId;
            Minor = minor;
            Average = average;
        }
        #endregion

        #region private methods
        private void validate(string minor, int average)
        {
            if (string.IsNullOrEmpty(minor))
                throw new InvalidEmployeeEducationException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.EducationMinor });
            if (average <= 0)
                throw new InvalidEmployeeEducationException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.EducationAverage });
        }
        #endregion
    }
}
