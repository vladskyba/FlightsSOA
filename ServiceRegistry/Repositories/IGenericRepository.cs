using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore.Query;
using ServicesRegistry.Models;

namespace ServicesRegistry.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : ServiceSettings
    {
        Task<IEnumerable<TEntity>> GetAsync(
                   Expression<Func<TEntity, bool>> filter = null,
                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<TEntity> UpsertAsync(TEntity entity);
    }
}
