using System.Linq;
using System.Threading.Tasks;
using Users.Domain;
using Users.ExternalDependencies;

namespace Users.StorageAccess
{
    public class UsersJsonAccessFacade : IUsersStorageFacade
    {
        public async Task<UserRow> GetUserByIdAsync(int userId) => 
            (await DataFile.ReadFromFileAsync<UserRow>()).FirstOrDefault(a => a.UserId == userId);

        public async Task<Address> GetAddressByUserIdAsync(int userId) => 
            (await DataFile.ReadFromFileAsync<Address>()).FirstOrDefault(a => a.UserId == userId);
    }
    public class UserRow
    {
        public int UserId { get; set; }
        public string Name { get; set; }
    }
}
