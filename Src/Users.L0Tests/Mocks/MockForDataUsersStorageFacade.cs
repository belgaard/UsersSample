using System;
using System.Threading.Tasks;
using LeanTest.Mock;
using Users.Domain;
using Users.ExternalDependencies;
using Users.StorageAccess;

namespace Users.L0Tests.Mocks
{
    public class MockForDataUsersStorageFacade : IUsersStorageFacade, IMockForData<UserRow>, IMockForData<Address>
    {
        private UserRow _user;
        private Address _address;

        public async Task<UserRow> GetUserByIdAsync(int userId) => await Task.FromResult(_user);
        public async Task<Address> GetAddressByUserIdAsync(int userId) => await Task.FromResult(_address);

        public void WithData(UserRow data) => _user = data;
        public void WithData(Address data) => _address = data;

        public void PreBuild() {}
        public void Build(Type type) {}
        public void PostBuild() {}
    }
}
