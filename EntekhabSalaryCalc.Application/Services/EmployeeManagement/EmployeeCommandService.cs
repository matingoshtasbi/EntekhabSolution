using AutoMapper;
using EntekhabSalaryCalc.Application.Core.Exceptions;
using EntekhabSalaryCalc.Application.Contracts.Abstractions.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement.BaseInfo;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Aggregates;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Localization;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ParameterObjects;
using EntekhabSalaryCalc.Domain.EmployeeManagement.Services;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Education;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.Insurance;
using EntekhabSalaryCalc.Domain.EmployeeManagement.ValueObjects.PhysicalInfo;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntekhabSalaryCalc.Application.Services.EmployeeManagement
{
    public class EmployeeCommandService : IEmployeeCommandService
    {
        #region members
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEducationLevelRepositoryEM _educationLevelRepository;
        private readonly IEducationMajorRepositoryEM _educationMajorRepository;
        private readonly IPhysicalInfoRepositoryEM _physicalInfoRepository;
        private readonly IServiceProvider _provider;
        private readonly IStringLocalizer<EmployeeManagementLocalization> _localizer;
        #endregion

        #region constractors
        public EmployeeCommandService(IMapper mapper,
            IEmployeeRepository employeeRepository,
            IEducationLevelRepositoryEM educationLevelRepository,
            IEducationMajorRepositoryEM educationMajorRepository,
            IPhysicalInfoRepositoryEM physicalInfoRepository,
            IServiceProvider provider,
            IStringLocalizer<EmployeeManagementLocalization> localizer)
        {
            _mapper = mapper;
            _employeeRepository = employeeRepository;
            _educationLevelRepository = educationLevelRepository;
            _educationMajorRepository = educationMajorRepository;
            _physicalInfoRepository = physicalInfoRepository;
            _provider = provider;
            _localizer = localizer;
        }
        #endregion

        #region private methods

        #region contact
        private void addContacts(List<EmployeeContactRequest> contacts, Employee employee)
        {
            foreach (var item in contacts)
                employee.AddContact(item.Title, item.Type, item.Value);
        }
        private void updateContacts(List<EmployeeContactRequest> contacts, Employee employee)
        {
            var currentIds = employee.Contacts.Select(c => c.Id).ToList();
            var addItems = contacts.Where(c => !currentIds.Contains(c.Id) && !c.IsDeleted);
            foreach (var item in addItems)
                employee.AddContact(item.Title, item.Type, item.Value);

            var updatedItems = contacts.Where(c => currentIds.Contains(c.Id) && !c.IsDeleted);
            foreach (var item in updatedItems)
                employee.UpdateContact(item.Id, item.Title, item.Type, item.Value);

            var deletedItems = contacts.Where(c => currentIds.Contains(c.Id) && c.IsDeleted);
            foreach (var item in deletedItems)
                employee.RemoveContact(item.Id);
        }
        #endregion

        #region education
        private void addEducations(List<EmployeeEducationRequest> educations, Employee employee)
        {
            foreach (var item in educations)
            {
                employee.AddEducation(item.LevelId, item.MajorId, item.Minor, item.Average);
            }
        }
        private void updateEducations(List<EmployeeEducationRequest> educations, Employee employee)
        {
            var currentIds = employee.Educations.Select(c => c.Id).ToList();
            var addItems = educations.Where(c => !currentIds.Contains(c.Id) && !c.IsDeleted);
            foreach (var item in addItems)
            {
                employee.AddEducation(item.LevelId, item.MajorId, item.Minor, item.Average);
            }

            var updatedItems = educations.Where(c => currentIds.Contains(c.Id) && !c.IsDeleted);
            foreach (var item in updatedItems)
            {
                employee.UpdateEducation(item.Id, item.LevelId, item.MajorId, item.Minor, item.Average);
            }

            var deletedItems = educations.Where(c => currentIds.Contains(c.Id) && c.IsDeleted);
            foreach (var item in deletedItems)
                employee.RemoveEducation(item.Id);
        }
        #endregion

        #region physicalInfo
        private void addPhysicalInfo(List<EmployeePhysicalInfoRequest> physicalInfo, Employee employee)
        {
            foreach (var item in physicalInfo)
            {
                employee.AddPhysicalInfo(item.PhysicalInfoId, item.Value);
            }
        }
        private void updatePhysicalInfo(List<EmployeePhysicalInfoRequest> physicalInfo, Employee employee)
        {
            var currentIds = employee.PhysicalInfo.Select(c => c.Id).ToList();
            var addItems = physicalInfo.Where(c => !currentIds.Contains(c.Id) && !c.IsDeleted);
            foreach (var item in addItems)
            {
                employee.AddPhysicalInfo(item.PhysicalInfoId, item.Value);
            }

            var updatedItems = physicalInfo.Where(c => currentIds.Contains(c.Id) && !c.IsDeleted);
            foreach (var item in updatedItems)
            {
                employee.UpdatePhysicalInfo(item.Id, item.PhysicalInfoId, item.Value);
            }

            var deletedItems = physicalInfo.Where(c => currentIds.Contains(c.Id) && c.IsDeleted);
            foreach (var item in deletedItems)
                employee.RemovePhysicalInfo(item.Id);
        }
        #endregion

        #endregion

        #region public methods

        #region employees
        public async Task<Guid> AddEmployee(EmployeeRequest request)
        {

            var employeePO = _mapper.Map<EmployeePO>(request);
            var employeeService = (IEmployeeService)_provider.GetService(typeof(IEmployeeService));
            var employee = EmployeeFactory.Create(employeePO, employeeService);

            addContacts(request.Contacts, employee);
            addEducations(request.Educations, employee);
            addPhysicalInfo(request.PhysicalInfo, employee);

            _employeeRepository.Add(employee);
            await _employeeRepository.UnitOfWork.SaveChangesAsync();

            return employee.Id;
        }
        public async Task UpdateEmployee(EmployeeRequest request)
        {
            if (!request.Id.HasValue)
                throw new ApplicationLayerException(EmployeeManagementLocalization.ResourseNotFound, new string[] { EmployeeManagementLocalization.Employee });

            var employeePO = _mapper.Map<EmployeePO>(request);

            var employee = _employeeRepository.Get(request.Id.Value);

            employee.EmployeeService = (IEmployeeService)_provider.GetService(typeof(IEmployeeService));
            employee.UpdateProperties(employeePO);
            updateContacts(request.Contacts, employee);
            updateEducations(request.Educations, employee);
            updatePhysicalInfo(request.PhysicalInfo, employee);

            await _employeeRepository.UnitOfWork.SaveChangesAsync();
        }
        public async Task RemoveEmployee(Guid employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);

            if (employee == null)
                throw new ApplicationLayerException("Employee Not Found.");

            _employeeRepository.Remove(employeeId);
            await _employeeRepository.UnitOfWork.SaveChangesAsync();
        }
        #endregion

        #region baseInfo
        public async Task<EmployeeBaseInfo> GetBaseInfo()
        {
            var baseInfo = new EmployeeBaseInfo();
            baseInfo.EducationLevels = _mapper.Map<List<EducationLevelDto>>(_educationLevelRepository.GetAll().ToList());
            baseInfo.EducationMajors = _mapper.Map<List<EducationMajorDto>>(_educationMajorRepository.GetAll().ToList());
            baseInfo.PhysicalInfos = _mapper.Map<List<PhysicalInfoDto>>(_physicalInfoRepository.GetAll().ToList());

            return baseInfo;
        }
        #endregion

        #endregion
    }
}
