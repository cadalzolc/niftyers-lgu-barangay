using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Niftyers;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly NiftyersDB Context;
    private readonly DbSet<TEntity> Query;
    private readonly IList<Expression<Func<TEntity, object>>> Modifiers;

    public Repository(NiftyersDB dbContext)
    {
        Context = dbContext;
        Query = Context.Set<TEntity>();
        Modifiers = new List<Expression<Func<TEntity, object>>>();
    }

    protected IQueryable<TEntity> Table
    {
        get
        {
            return Modifiers.Aggregate((IQueryable<TEntity>)Query, (current, include) => current.Include(include));
        }
    }

    public TEntity Find(Func<TEntity, bool> predicate)
    {
        return Table.SingleOrDefault(predicate);
    }

    public IQueryable<TEntity> List()
    {
        return Table;
    }

    public bool Create(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        return Context.SaveChanges().ToBoolean();
    }

    public bool Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        return Context.SaveChanges().ToBoolean();
    }

    public bool Delete(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        return Context.SaveChanges().ToBoolean();
    }

    public IRepository<TEntity> Include(Expression<Func<TEntity, object>> path)
    {
        Modifiers.Add(path);
        return this;
    }

    public bool Exists(Func<TEntity, bool> predicate)
    {
        return Table.Any(predicate);
    }

}