using System.Threading.Tasks;
using Users.StorageAccess;

namespace Users.ExternalDependencies
{
    public interface IUsersStorageFacade
    {
        Task<UserRow> GetUserByIdAsync(int userId);
        Task<AddressRow> GetAddressByUserIdAsync(int userId);
    }
}