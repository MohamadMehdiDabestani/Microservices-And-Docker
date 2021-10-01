using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ordring.Domain.Common;
namespace Ordering.Application.Contracts.Persistance
{
    public interface IAsyncRepo<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAll();

        Task<IReadOnlyList<T>> Get(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> Get(Expression<Func<T, bool>> predicate = null 
            , Func<IQueryable<T> , IOrderedQueryable<T>> order = null , string includeString = null , bool disableTracking=true);

        Task<IReadOnlyList<T>> Get(Expression<Func<T, bool>> predicate = null
            , Func<IQueryable<T>, IOrderedQueryable<T>> order = null, List<Expression<Func<T , object>>> includes = null
            , bool disableTracking = true);

        Task<T> GetById(int id);

        Task<T> Add(T entity);
        
        Task Update(T entity);
        
        Task Delete(T entity);
    }
}
