using APP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Infrustructure.Abstract
{
    public interface  IGenaricRepository<T> where T : ModelBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Delete(T entity);
        void Update(T entity);  

    }
}
