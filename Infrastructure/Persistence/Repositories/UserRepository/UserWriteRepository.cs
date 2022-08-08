using Application.Repositories.UserRepository;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRepository
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
