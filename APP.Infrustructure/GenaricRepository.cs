using APP.Data.Models;
using APP.Infrustructure.Abstract;
using APP.Infrustructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Infrustructure
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : ModelBase
    {
        private readonly APPDbContext _dbContext;

        public GenaricRepository(APPDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(T entity)
        {
           await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            if(typeof(T) == typeof(Employee))
            {
              return (IReadOnlyList<T>) await _dbContext.Set<Employee>().AsNoTracking().Include(E=>E.Department).ToListAsync();
            }
         return  await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            if (typeof(T) == typeof(Employee))
            {
                return await _dbContext.Set<Employee>().AsNoTracking().Where(e=>e.Id ==id).Include(e=>e.Department).FirstOrDefaultAsync() as T;
            }
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
