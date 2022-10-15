using System.Linq.Expressions;
using EventHub.Domain;

namespace EventHub.Application.Common.Interfaces
{
    public interface IRepository
    {
        Task<T?> GetById<T>(Guid id) where T : Entity;
        Task<T?> GetByIdWithInclude<T>(Guid id, params Expression<Func<T, object>>[] includeProperties) where T : Entity;
        void Add<T>(T entity) where T : Entity;
        Task<T?> Remove<T>(Guid id) where T : Entity;
        Task Save();
    }
}
