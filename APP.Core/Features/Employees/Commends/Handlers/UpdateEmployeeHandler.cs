using APP.Core.Features.Employees.Commends.Models;
using APP.Core.Features.Employees.Queries.Handlers;
using APP.Core.Features.Employees.Results;
using APP.Core.Resources;
using APP.Data.Models;
using APP.Service.Abstracts;
using AutoMapper;
using Azure;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Features.Employees.Commends.Handlers
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommend, string>
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _sharedResources;

        public UpdateEmployeeHandler(IEmployeeService employeeService ,IMapper mapper , IStringLocalizer<SharedResources> stringLocalizer )
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _sharedResources = stringLocalizer;
        }

        public async Task<string> Handle(UpdateEmployeeCommend request, CancellationToken cancellationToken)
        {
            var emp =await _employeeService.GetByIdAsync(request.Id);
            if (emp == null)
                return _sharedResources[SharedResourcesKey.NotFound];
            var empMap = new Employee() {
                Id = request.Id,
                Name = request.Name ,
                Phone = request.Phone ,
                Adress = request.Adress,
                Age = request.Age,
                Salary = request.Salary ,
                DepartmentId = request.DepartmentId,
                RowVersion =emp.RowVersion,
                
            };
            //var empMap = _mapper.Map<Employee>(request);
            var result = await _employeeService.Edit(empMap);
            if (result > 0)
                return _sharedResources[SharedResourcesKey.Done];
            return _sharedResources[SharedResourcesKey.Error];
        }
    }
}
