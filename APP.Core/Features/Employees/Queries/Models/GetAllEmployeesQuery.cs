using APP.Core.Features.Employees.Results;
using APP.Data.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Features.Employees.Queries.Models
{
    public class GetAllEmployeesQuery : IRequest<IReadOnlyList<EmployeeToReturnDto>>
    {
    }
}
