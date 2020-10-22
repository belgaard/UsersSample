using System.Threading.Tasks;
using Users.Domain;
using Users.StorageAccess;

namespace Users.ExternalDependencies
{
    public interface IUsersStorageFacade
    {
        Task<UserRow> GetUserByIdAsync(int userId);
        Task<Address> GetAddressByUserIdAsync(int userId);
    }
}