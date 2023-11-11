using ShootScares.API.Domain.Entities;

namespace ShootScares.API.Data
{
    public interface IRepository<T> where T : class, IEntity
    {
        T Add(T newItem);
        IQueryable<T> GetAll();
        IQueryable<T> Get(int id);
        T Update(T item);
        bool Delete(T item);
        bool EntityExists(int id);
    }
}
