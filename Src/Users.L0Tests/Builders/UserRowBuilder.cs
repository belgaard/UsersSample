using Users.StorageAccess;

namespace Users.L0Tests.Builders
{
    internal class UserRowBuilder
    {
        private int _userId;
        private string _name;

        public UserRowBuilder WithUserId(int userId) { _userId = userId; return this; }
        public UserRowBuilder WithName(string name) { _name = name; return this; }

        public UserRow Build() => new UserRow{UserId = _userId, Name=_name};
    }
}