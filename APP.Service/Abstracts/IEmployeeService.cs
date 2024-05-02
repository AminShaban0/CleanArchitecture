using APP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Service.Abstracts
{
    public interface IEmployeeService
    {
        Task<IReadOnlyList<Employee>> GetAllAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<int> Edit(Employee entity);

    }
}
