using Users.StorageAccess;

namespace Users.L0Tests.TestData
{
    public static class UserRows
    {
        public static UserRow UserJohnDoeWithId42 { get; } = new UserRow {UserId = 42, Name = "John Doe"};
    }
}
