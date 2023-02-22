using System;
using System.Linq;
using System.Linq.Expressions;

namespace Niftyers;

public interface IRespositoryResident<Tentity> where Tentity: class
{
    IRespositoryResident<Tentity> Include(Expression<Func<Tentity, object>> path);
    Tentity Find(Func<Tentity, bool> predicate);
    IQueryable<Tentity> List();
    IQueryable<Tentity> List(Func<Tentity, bool> predicate);
    bool Create(Tentity entity);
    bool Update(Tentity entity);
}
