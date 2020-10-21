using System.Linq;
using System.Threading.Tasks;
using Users.Domain;
using Users.ExternalDependencies;

namespace Users.StorageAccess
{
    public class UsersJsonAccessFacade : IUsersStorageFacade
    {
        public async Task<User> GetUserByIdAsync(int userId)
        {
            User userByIdAsync = (await DataFile.ReadFromFileAsync<User>()).FirstOrDefault(a => a.UserId == userId);
            return userByIdAsync;
        }

        public async Task<Address> GetAddressByUserIdAsync(int userId) => 
            (await DataFile.ReadFromFileAsync<Address>()).FirstOrDefault(a => a.UserId == userId);
    }
}
