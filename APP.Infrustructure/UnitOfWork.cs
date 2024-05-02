using APP.Data.Models;
using APP.Infrustructure.Abstract;
using APP.Infrustructure.Data;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Infrustructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly APPDbContext _dbContext;

        public UnitOfWork(APPDbContext dbContext)
        {
            _dbContext = dbContext;
            repoistories = new Hashtable();
        }
        Hashtable repoistories;
        public async Task<int> CompleteAsync()
        {
          return await _dbContext.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
           await _dbContext.DisposeAsync();
        }

        public IGenaricRepository<Tentity> Repository<Tentity>() where Tentity : ModelBase
        {
            var key = typeof(Tentity).Name;
            if(!repoistories.ContainsKey(key))
            {
                var repository = new GenaricRepository<Tentity>(_dbContext);
                repoistories.Add(key, repository);
            }
            return repoistories[key] as IGenaricRepository<Tentity>;
        }

        public IDbContextTransaction BeginTransaction()
        {
            var transaction =_dbContext.Database.BeginTransaction();
            return transaction;
            
        }
    }
}
