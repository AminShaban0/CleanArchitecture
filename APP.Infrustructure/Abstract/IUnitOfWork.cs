using APP.Data.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP.Infrustructure.Abstract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IGenaricRepository<Tentity> Repository<Tentity>() where Tentity : ModelBase;
        Task<int> CompleteAsync();
        IDbContextTransaction BeginTransaction();
    }
}
