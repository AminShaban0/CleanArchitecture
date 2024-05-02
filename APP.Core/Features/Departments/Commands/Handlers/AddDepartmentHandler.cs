using APP.Core.Features.Departments.Commands.Models;
using APP.Core.Features.Employees.Results;
using APP.Data.Models;
using APP.Service.Abstracts;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Features.Departments.Commands.Handlers
{
    public class AddDepartmentHandler : IRequestHandler<AddDepartmentCommend, AddDepartmentCommend>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public AddDepartmentHandler(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }
        public async Task<AddDepartmentCommend> Handle(AddDepartmentCommend request, CancellationToken cancellationToken)
        {
            var DepMap = _mapper.Map<Department>(request);
            var result = await _departmentService.AddAsync(DepMap);
            if (result > 0)
                return request;
            return null;

        }
    }
}
