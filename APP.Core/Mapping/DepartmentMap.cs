using APP.Core.Features.Departments.Commands.Models;
using APP.Data.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Core.Mapping
{
    public class DepartmentMap:Profile
    {
        public DepartmentMap()
        {
            CreateMap<AddDepartmentCommend, Department>();
        }
    }
}
