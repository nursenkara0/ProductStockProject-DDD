using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.Repositories;
using Domain.Common;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ProjectDbContext _context;

        public ReadRepository(ProjectDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            return tracking ? Table.AsQueryable() : Table.AsNoTracking();
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            return await GetAll(tracking).FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return await GetAll(tracking).FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            return GetAll(tracking).Where(method);
        }
    }
}
