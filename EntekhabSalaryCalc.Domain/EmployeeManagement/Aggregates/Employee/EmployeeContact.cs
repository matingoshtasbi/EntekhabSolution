using EntekhabSalaryCalc.Application.Core.Domain;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates
{
    public class EmployeeContact : Entity<long>
    {
        #region constractors

        public EmployeeContact()
        {
        }

        public EmployeeContact(string title, ContactTypeEnum type, string value)
        {
            validate(title , type , value);
            Title = title;
            Type = type;
            Value = value;
        }

        #endregion

        #region properties

        //public Guid  EmployeeId{ get; set; } = default!;
        public string Title { get; set; } = default!;
        public ContactTypeEnum Type { get; set; } = default!;
        public string Value { get; set; } = default!;
        #endregion

        #region public methodes
        internal void UpdateProperties(string title, ContactTypeEnum type, string value)
        {
            validate(title, type , value);
            Title = title;
            Type = type;
            Value = value;
        }
        #endregion

        #region private methods
        private void validate(string title, ContactTypeEnum type, string value)
        {
            if (string.IsNullOrEmpty(title))
                throw new InvalidEmployeeContactException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.ContactTitle });
            if (!Enum.IsDefined(typeof(ContactTypeEnum), type))
                throw new InvalidEmployeeContactException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.ContactType });
            if (string.IsNullOrEmpty(value))
                throw new InvalidEmployeeContactException(EmployeeManagementLocalization.FieldCannotBeEmpty, new string[] { EmployeeManagementLocalization.ContactValue });

        }
        #endregion
    }
}
