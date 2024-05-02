using APP.Data.Models;
using APP.Infrustructure.Abstract;
using APP.Infrustructure.Data;
using APP.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Service.Implementations
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {

            _unitOfWork = unitOfWork;
        }

        public async Task<int> Edit(Employee entity)
        {
           //_unitOfWork.Repository<Employee>().Delete(entity);
           _unitOfWork.Repository<Employee>().Update(entity);
            return await _unitOfWork.CompleteAsync();
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync()
        {
            var employees = await _unitOfWork.Repository<Employee>().GetAllAsync();
            return employees;

        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var employee =await _unitOfWork.Repository<Employee>().GetByIdAsync(id);
            return employee;
        }
    }
}
