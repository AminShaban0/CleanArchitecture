using APP.Data.Models;
using APP.Infrustructure.Abstract;
using APP.Service.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Service.Implementations
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddAsync(Department entity)
        {

                await _unitOfWork.Repository<Department>().AddAsync(entity);
                return await _unitOfWork.CompleteAsync();

        }
    }
}
