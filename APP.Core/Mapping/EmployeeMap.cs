using APP.Core.Features.Employees.Commends.Models;
using APP.Core.Features.Employees.Results;
using APP.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Mapping
{
    public class EmployeeMap:Profile
    {
        public EmployeeMap()
        {
            CreateMap<Employee,EmployeeToReturnDto>()
                .ForMember(E=>E.DepartmentName,O=>O.MapFrom(s=>s.Department.Name));
            CreateMap<UpdateEmployeeCommend, Employee>()
                .ForMember(e=>e.RowVersion,o=>o.MapFrom(s=>s.RowVersion));
        }
    }
}
