using Application.Repositories.UserRepository;
using Domain.Entities;
using Infrastructure.JwtHelpers;
using Microsoft.Extensions.Options;
using Persistence.Contexts;

namespace Persistence.Repositories.UserRepository
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        private readonly AppSettings _appSettings;
        public UserReadRepository(ProjectDbContext context, IOptions<AppSettings> appSettings) : base(context)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string email, string password)
        {
            var user = Table.FirstOrDefault(x => x.Email == email && x.Password == password);
            return user;
        }
    }
}
