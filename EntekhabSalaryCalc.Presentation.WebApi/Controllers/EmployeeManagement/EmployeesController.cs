using AutoMapper;
using EntekhabSalaryCalc.Application.Contracts.Abstractions.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement;
using EntekhabSalaryCalc.Application.Contracts.DTOs.EmployeeManagement.BaseInfo;
using EntekhabSalaryCalc.Application.Contracts.ViewModels.EmployeeManagement;
using EntekhabSalaryCalc.Application.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EntekhabSalaryCalc.Presentation.WebApi.Controllers.EmployeeManagement
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        #region members
        private readonly ILogger<EmployeeVM> _logger;
        private readonly IEmployeeCommandService _employeeCommandService;
        private readonly IEmployeeQueryService _employeeQueryService;
        private readonly IMapper _mapper;
        #endregion

        #region constractors
        public EmployeesController(ILogger<EmployeeVM> logger,
            IMapper mapper,
            IEmployeeCommandService employeeCommandService,
            IEmployeeQueryService employeeQueryService)
        {
            _logger = logger;
            _employeeCommandService = employeeCommandService;
            _employeeQueryService = employeeQueryService;
            _mapper = mapper;
        }
        #endregion

        #region public methods

        #region employees
        [HttpGet]
        public async Task<ActionResult<PageResult<EmployeeVM>>> GetAll([FromQuery] FindEmployeesRequest request)
        {
            return Ok(await _employeeQueryService.FindEmployees(request));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeVM>> Get(string id)
        {
            var vm = await _employeeQueryService.FindEmployee(Guid.Parse(id));
            return Ok( vm);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Guid>> AddEmployee([FromBody] EmployeeRequest request)
        {
            
            return Ok(await _employeeCommandService.AddEmployee(request));
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateEmployee([FromBody] EmployeeRequest request)
        {
            await _employeeCommandService.UpdateEmployee(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(Guid id)
        {
            await _employeeCommandService.RemoveEmployee(id);
            return Ok();
        }
        #endregion

        #region baseInfoes
        [HttpGet()]
        [Route("[action]")]
        public async Task<ActionResult<EmployeeBaseInfo>> GetBaseInfo()
        {
            return Ok(await _employeeCommandService.GetBaseInfo());
        }
        #endregion

        #endregion
    }
}
