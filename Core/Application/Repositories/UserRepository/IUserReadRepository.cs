using Domain.Entities;

namespace Application.Repositories.UserRepository
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        User Authenticate(string email, string password);
    }

}
