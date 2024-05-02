using APP.Core.Features.Employees.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Features.Employees.Queries.Models
{
    public class GetEmployeeByIdQuery:IRequest<EmployeeToReturnDto>
    {
        public GetEmployeeByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
