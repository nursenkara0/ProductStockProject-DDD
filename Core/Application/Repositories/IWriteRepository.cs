using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> models);
        bool Remove(T model);
        bool RemoveRange(List<T> models);
        Task<bool> Remove(string id);
        bool Update(T model);

        Task<int> SaveAsync();
    }
}
