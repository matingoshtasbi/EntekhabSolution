using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ParameterObjects;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Services;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates
{
    public static class EmployeeFactory
    {
        public static Employee Create(EmployeePO po, IEmployeeService employeeService) 
        {
            var employee = new Employee(po, employeeService);  
            //employee.GenerateNewIdentity();

            return employee;    
        }

        internal static EmployeeContact CreateContact(string title, ContactTypeEnum type, string value)
        {
            var employeeContact = new EmployeeContact(title, type, value);
            //employeeContact.GenerateNewIdentity();

            return employeeContact;

        }

        internal static EmployeeEducation CreateEducation(long levelId, long majorId , string minor,  int average)
        {
            var employeeEducation = new EmployeeEducation(levelId, majorId , minor , average);
            return employeeEducation;
        }

        internal static EmployeePhysicalInfo CreatePhysicalInfo(long physicalInfoId, string value)
        {
            var employeePhysicalInfo = new EmployeePhysicalInfo(physicalInfoId, value);
            return employeePhysicalInfo;
        }

    }
}
