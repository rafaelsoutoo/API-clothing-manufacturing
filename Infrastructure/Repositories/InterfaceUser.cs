using Infrastructure.Models;

namespace Infrastructure.Repositories
{
    public interface InterfaceUser
    {
        Task CreateUser(User Objeto);

        Task<User> GetUserById(Guid id);

        Task<User> GetUserByEmail(string email);

    }
}
