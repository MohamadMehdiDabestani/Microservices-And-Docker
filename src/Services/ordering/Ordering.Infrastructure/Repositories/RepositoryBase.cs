using Ordering.Application.Contracts.Persistance;
using Ordering.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Ordering.Infrastructure.Repositories
{
    public class RepositoryBase<T> : IAsyncRepo<T> where T : Ordring.Domain.Common.EntityBase
    {
        protected readonly OrderingContext db;

        public RepositoryBase(OrderingContext db)
        {
            this.db = db;
        }

        public async Task<T> Add(T entity)
        {
            db.Set<T>().Add(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> Get(Expression<Func<T, bool>> predicate)
        {
            return await db.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<IReadOnlyList<T>> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> order = null, string includeString = null, bool disableTracking = true)
        {
            IQueryable<T> query = db.Set<T>();
            if (disableTracking) query.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(includeString)) query = query.Include(includeString);

            if (predicate != null) query = query.Where(predicate);

            if (order != null)
                return await order(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> Get(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> order = null, List<Expression<Func<T, object>>> includes = null, bool disableTracking = true)
        {
            IQueryable<T> query = db.Set<T>();
            if (disableTracking) query.AsNoTracking();

            if (includes != null) query = includes.Aggregate(query, (current ,include) => current.Include(include));

            if (predicate != null) query = query.Where(predicate);

            if (order != null)
                return await order(query).ToListAsync();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
