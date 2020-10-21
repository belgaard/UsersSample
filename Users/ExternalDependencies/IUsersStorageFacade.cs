using System.Threading.Tasks;
using Users.Domain;

namespace Users.ExternalDependencies
{
    public interface IUsersStorageFacade
    {
        Task<User> GetUserByIdAsync(int userId);
        Task<Address> GetAddressByUserIdAsync(int userId);
    }
}