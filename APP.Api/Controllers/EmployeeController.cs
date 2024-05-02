using APP.Core.Features.Employees.Commends.Models;
using APP.Core.Features.Employees.Queries.Models;
using APP.Core.Features.Employees.Results;
using APP.Data.Models;
using APP.Infrustructure.Abstract;
using APP.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.Api.Controllers
{

    public class EmployeeController : BaseController
    {

        private readonly IEmployeeService _employeeService;
        private readonly IMediator _mediator;

        public EmployeeController(IEmployeeService employeeService, IMediator mediator)
        {
            _employeeService = employeeService;
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<EmployeeToReturnDto>>> getAll()
        {
            //var employees = await _employeeService.GetAllAsync();
            //return Ok(employees);
            var employee = await _mediator.Send(new GetAllEmployeesQuery());
            return Ok(employee);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeToReturnDto>> GetById(int id)
        {
            var employee =await _mediator.Send(new GetEmployeeByIdQuery(id));
            if (employee == null) 
                return NotFound();
            return Ok(employee);
        }
        [HttpPut]
        public async Task<ActionResult> Update([FromQuery]UpdateEmployeeCommend commend)
        {
            var employee =await _mediator.Send(commend);
            //if (employee == null)
            //    return BadRequest();
            return Ok(employee); 
        }
        
    }
}
