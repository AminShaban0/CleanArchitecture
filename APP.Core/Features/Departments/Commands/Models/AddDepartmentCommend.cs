using APP.Core.Features.Employees.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Features.Departments.Commands.Models
{
    public class AddDepartmentCommend : IRequest<AddDepartmentCommend>
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
