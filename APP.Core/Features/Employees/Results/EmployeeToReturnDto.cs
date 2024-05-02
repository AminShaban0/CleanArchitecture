using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Features.Employees.Results
{
    public class EmployeeToReturnDto
    {
        public string Name { get; set; }

        public int Age { get; set; }
        public string Adress { get; set; }

        public decimal Salary { get; set; }

        public string Phone { get; set; }
        public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
