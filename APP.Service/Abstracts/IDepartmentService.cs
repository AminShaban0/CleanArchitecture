using APP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Service.Abstracts
{
    public interface IDepartmentService
    {
        Task<int> AddAsync(Department entity);
    }
}
