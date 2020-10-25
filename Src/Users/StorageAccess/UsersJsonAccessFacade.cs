using System.Linq;
using System.Threading.Tasks;
using Users.ExternalDependencies;

namespace Users.StorageAccess
{
    public class UsersJsonAccessFacade : IUsersStorageFacade
    {
        public async Task<UserRow> GetUserByIdAsync(int userId) => 
            (await DataFile.ReadFromFileAsync<UserRow>()).FirstOrDefault(a => a.UserId == userId);

        public async Task<AddressRow> GetAddressByUserIdAsync(int userId) => 
            (await DataFile.ReadFromFileAsync<AddressRow>()).FirstOrDefault(a => a.UserId == userId);
    }
}
