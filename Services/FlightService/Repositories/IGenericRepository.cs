using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore.Query;
using Flight.Models;

namespace Flight.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAsync(
                   Expression<Func<TEntity, bool>> filter = null,
                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> UpsertAsync(TEntity entity);
    }
}
