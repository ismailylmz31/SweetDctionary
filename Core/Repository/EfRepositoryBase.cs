using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Repository;

public class EfRepositoryBase<TContext, TEntity, TId> : IRepository<TEntity, TId>
    where TEntity : Entity<TId>, new()
    where TContext : DbContext

{
    public TEntity Add(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public TEntity Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public List<TEntity> GetAll()
    {
        throw new NotImplementedException();
    }

    public TEntity? GetById(TId id)
    {
        throw new NotImplementedException();
    }

    public TEntity Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
