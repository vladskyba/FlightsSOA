using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using ServiceRegistry.Context;
using ServicesRegistry.Models;

namespace ServicesRegistry.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : ServiceSettings
    {
        protected readonly ServiceRegistryContext _context;
    
        public GenericRepository(ServiceRegistryContext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
    
            if (include != null)
            {
                query = include(query);
            }
    
            if (filter != null)
            {
                query = query.Where(filter);
            }
    
            if (orderBy != null)
            {
                query = orderBy(query);
            }
    
            return await query.ToListAsync();
        }

        public async Task<TEntity> UpsertAsync(TEntity entity)
        {
            var exist = await _context.Set<TEntity>()
                          .AsNoTracking()
                          .FirstOrDefaultAsync(x => x.Port == entity.Port);

            if (exist == null)
            {
                _context.Set<TEntity>().Add(entity);
            }
            else
            {
                _context.Set<TEntity>().Update(entity);
            }

            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
