using System.Linq.Expressions;

namespace Niftyers;

public interface IRepository<TEntity> where TEntity : class 
{
    IRepository<TEntity> Include(Expression<Func<TEntity, object>> path);
    TEntity Find(Func<TEntity, bool> predicate);
    IQueryable<TEntity> List();
    bool Create(TEntity entity);
    bool Update(TEntity entity);
    bool Delete(TEntity entity);
    bool Exists(Func<TEntity, bool> predicate);
}