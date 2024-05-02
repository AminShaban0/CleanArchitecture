using APP.Core.Features.Employees.Queries.Models;
using APP.Core.Features.Employees.Results;
using APP.Data.Models;
using APP.Service.Abstracts;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Features.Employees.Queries.Handlers
{
    
    public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeesQuery, IReadOnlyList<EmployeeToReturnDto>>,
                                         IRequestHandler<GetEmployeeByIdQuery,EmployeeToReturnDto>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        public GetAllEmployeeHandler(IEmployeeService employeeService , IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<EmployeeToReturnDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
          var result = await _employeeService.GetAllAsync();
            return _mapper.Map<IReadOnlyList<EmployeeToReturnDto>>(result);
           
        }

        public async Task<EmployeeToReturnDto> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var resuit =await _employeeService.GetByIdAsync(request.Id);
            if (resuit == null)
                return null;
            return _mapper.Map<EmployeeToReturnDto>(resuit);
        }
    }
}
