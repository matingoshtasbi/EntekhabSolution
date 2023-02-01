using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Enums;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Exceptions;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Localization;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ParameterObjects;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Services;
using EntekhabSalaryCalc.Domain.Test.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Domain.Test.EmployeeManagement
{
    public class EmployeeTest : BaseTestClass
    {
        IEmployeeService _employeeService;
        IEmployeeRepository _employeeRepository;
        public EmployeeTest():base()
        {
            _employeeService = (IEmployeeService)ServiceProvider.GetService(typeof(IEmployeeService));
            _employeeRepository = (IEmployeeRepository)ServiceProvider.GetService(typeof(IEmployeeRepository));
        }

        private EmployeePO createEmployeePO()
        {
            return new EmployeePO
            {
                IdNo = "0022804773",
                Code = "1",
                FirstName = "Matin",
                LastName = "Goshtasbi",
                Birthplace = "Tehran",
                Birthdate = DateTime.Now.AddYears(-20),
                EmploymentDate = DateTime.Now,
                FatherName = "Masoud",
                GenderId = 0,
                InsuranceId = 0,
                InsuranceNo = "120062",
                MaritalStatusId = 0,
                MilitaryServiceStatusId = 0,
                Nationality = "Iran",
                NumberOfDependents = 0,
                ReleaseDate = DateTime.Now.AddYears(1),
                SupplementaryInsuranceId = 0,
                SupplementaryInsuranceNo = "100256988"
            };

        }


        [Fact]
        public void ErrorIfIdNoIsEmpty()
        {
            //LocalIocManager
            EmployeePO employeePO = createEmployeePO();
            employeePO.IdNo = "";
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfCodeIsEmpty()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.Code = "";
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfFirstNameIsEmpty()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.FirstName = "";
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfLastNameIsEmpty()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.LastName = "";
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfIdNoRepetitious()
        {
            EmployeePO employeePO = createEmployeePO();
                employeePO.IdNo = "47";

            if (!_employeeRepository.Get(c => c.IdNo == "47").Any())
            {
                var employee = EmployeeFactory.Create(employeePO, _employeeService);
                _employeeRepository.Add(employee);
                _employeeRepository.UnitOfWork.SaveChanges();
            }

            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
            _employeeRepository.Remove(_employeeRepository.Get(c => c.IdNo == "47").FirstOrDefault().Id);
            _employeeRepository.UnitOfWork.SaveChanges();

            //if (ex.Message == "IdNo cannot be empty.")
            //    Assert.True(true);

        }

        [Fact]
        public void ErrorIfCodeRepetitious()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.Code = "47";

            if (!_employeeRepository.Get(c => c.Code == "47").Any())
            {
                var employee = EmployeeFactory.Create(employeePO, _employeeService);
                _employeeRepository.Add(employee);
                _employeeRepository.UnitOfWork.SaveChanges();
            }

            employeePO.IdNo = "2";
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));

            _employeeRepository.Remove(_employeeRepository.Get(c => c.Code == "47").FirstOrDefault().Id);
            _employeeRepository.UnitOfWork.SaveChanges();
        }

        [Fact]
        public void ErrorIfGenderNotFound()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.GenderId = 47;
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfMaritalStatusNotFound()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.MaritalStatusId = 47;
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfMilitaryServiceStatusNotFound()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.MilitaryServiceStatusId = 47;
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfBirthDateBiggerThanEmploymentDate()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.Birthdate = DateTime.Now.AddDays(1);
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfEmploymentDateBiggerThanReleaseDate()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.ReleaseDate = DateTime.Now.AddDays(-1);
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfInsuranceNotFound()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.InsuranceId = 47;
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

        [Fact]
        public void ErrorIfSupplementaryInsuranceNotFound()
        {
            EmployeePO employeePO = createEmployeePO();
            employeePO.SupplementaryInsuranceId = 47;
            Assert.Throws<InvalidEmployeeValueException>(() => EmployeeFactory.Create(employeePO, _employeeService));
        }

    }
}
