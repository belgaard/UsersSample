using System;
using System.Threading.Tasks;
using LeanTest.Mock;
using Users.ExternalDependencies;
using Users.StorageAccess;

namespace Users.L0Tests.Mocks
{
    public class MockForDataUsersStorageFacade : IUsersStorageFacade, IMockForData<UserRow>, IMockForData<AddressRow>
    {
        private UserRow _user;
        private AddressRow _address;

        public async Task<UserRow> GetUserByIdAsync(int userId) => await Task.FromResult(_user);
        public async Task<AddressRow> GetAddressByUserIdAsync(int userId) => await Task.FromResult(_address);

        public void WithData(UserRow data) => _user = data;
        public void WithData(AddressRow data) => _address = data;

        public void PreBuild() {}
        public void Build(Type type) {}
        public void PostBuild() {}
    }
}
