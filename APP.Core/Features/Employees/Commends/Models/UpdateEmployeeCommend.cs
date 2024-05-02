using APP.Core.Features.Employees.Results;
using Azure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Features.Employees.Commends.Models
{
    public class UpdateEmployeeCommend:IRequest<string>
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        public string Adress { get; set; }

        public decimal Salary { get; set; }

        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public byte[]? RowVersion { get; set; }

    }
}
