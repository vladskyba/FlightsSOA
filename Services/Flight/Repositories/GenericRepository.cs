using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Flight.Models;
using System;
using Flight.Context;

namespace Flight.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly FlightContext _context;
    
        public GenericRepository(FlightContext context)
        {
            _context = context;
        }
    
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
    
            return entity;
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
    
        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var exist = await _context.Set<TEntity>()
                                      .AsNoTracking()
                                      .FirstOrDefaultAsync(x => x.Id == entity.Id);
    
            if (exist == null)
            {
                return null;
            }
    
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
    
            return entity;
        }
    }
}
