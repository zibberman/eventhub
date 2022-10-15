using System.Linq.Expressions;
using EventHub.Application.Common.Interfaces;
using EventHub.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventHub.Infrastructure.Repositories
{
    public class GenericRepository : IRepository
    {
        private readonly EventHubDbContext _context;

        public GenericRepository(EventHubDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetById<T>(Guid id) where T : Entity
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task<T?> GetByIdWithInclude<T>(Guid id, params Expression<Func<T, object>>[] includeProperties) where T : Entity
        {
            var query = IncludeProperties(includeProperties);
            return await query.FirstOrDefaultAsync(n => n.Id == id);
        }

        public void Add<T>(T entity) where T : Entity
        {
            _context.Add<T>(entity);
        }

        public async Task<T?> Remove<T>(Guid id) where T : Entity
        {
            var evt = await _context.FindAsync<T>(id);
            if (evt == null)
                return null;
            _context.Remove<T>(evt);
            return evt;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        private IQueryable<T> IncludeProperties<T>(params Expression<Func<T, object>>[] includeProperties) where T : Entity
        {
            IQueryable<T> entities = _context.Set<T>();
            foreach (var includeProperty in includeProperties)
                entities = entities.Include(includeProperty);
            return entities;
        }
    }
}
