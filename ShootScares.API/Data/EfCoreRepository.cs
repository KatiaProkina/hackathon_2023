using ShootScares.API.Domain;
using ShootScares.API.Domain.Entities;

namespace ShootScares.API.Data
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : GameDbContext
    {
        private protected readonly TContext context;

        public EfCoreRepository(TContext context)
        {
            this.context = context;
        }

        public TEntity Add(TEntity newItem)
        {
            context.Set<TEntity>().Add(newItem);
            context.SaveChanges();
            return newItem;
        }

        public bool Delete(TEntity item)
        {
            var deleted = context.Set<TEntity>().Remove(item);
            context.SaveChanges();
            return deleted != null;
        }

        public bool EntityExists(int id) =>
            context.Set<TEntity>().Find(id) != null;

        public IQueryable<TEntity> Get(int id) =>
            context.Set<TEntity>().Where(e => e.Id == id);

        public IQueryable<TEntity> GetAll() =>
            context.Set<TEntity>().AsQueryable();

        public TEntity Update(TEntity item)
        {
            var updated = context.Set<TEntity>().Update(item).Entity;
            context.SaveChanges();
            return updated;
        }
    }
}
