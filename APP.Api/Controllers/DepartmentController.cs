using APP.Core.Features.Departments.Commands.Models;
using APP.Data.Models;
using APP.Infrustructure.Abstract;
using APP.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APP.Api.Controllers
{

    public class DepartmentController : BaseController
    {
        
        private readonly IDepartmentService _departmentService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public DepartmentController( IUnitOfWork unitOfWork ,IMediator mediator)
        {
            
            
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<AddDepartmentCommend>> AddDep([FromQuery]AddDepartmentCommend Dep)
        {
           
                var department = await _mediator.Send(Dep);
                if (department == null)
                    return BadRequest();
                return Ok(Dep);
           
        }
        [HttpPost("Test")]
        public async Task<ActionResult> TestTransaction()
        {
            using var transaction =_unitOfWork.BeginTransaction();
            
            try
            {
                await _unitOfWork.Repository<Department>().AddAsync(new Department() { Code = "1", Name = "Test" });
                await _unitOfWork.CompleteAsync();
                transaction.CreateSavepoint("FristPoint");
                await _unitOfWork.Repository<Department>().AddAsync(new Department() { Id =15 , Code = "2", Name = "Test02" });
                await _unitOfWork.CompleteAsync();
                await _unitOfWork.Repository<Department>().AddAsync(new Department() { Code = "3", Name = "Test03" });
                await _unitOfWork.CompleteAsync();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.RollbackToSavepoint("FristPoint");
                transaction.Commit();
            }
            return Ok();

        }
    }
}
