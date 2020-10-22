using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using LeanTest;
using LeanTest.Core.ExecutionHandling;
using LeanTest.Xunit;
using Users.Domain;
using Xunit;
using Xunit.Abstractions;

namespace Users.L0Tests
{
    public class TestUsersService
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly HttpClient _target;

        public TestUsersService(ITestOutputHelper output)
        {
            var testContext = new TestContext(output);
            _contextBuilder = ContextBuilderFactory.CreateContextBuilder()
                .RegisterAttributes(testContext)
                .Build();
            _target = _contextBuilder.GetHttpClient();
        }

        [Fact]
        public async Task GetUserMustReturnRequestedUser()
        {
            _contextBuilder
                .WithData(TestData.UserRows.UserJohnDoeWithId42)
                .Build();

            HttpResponseMessage actual = await _target.GetAsync("users?userId=42");

            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
            User actualUser = JsonSerializer.Deserialize<User>(await actual.Content.ReadAsStringAsync(), new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            MultiAssert.Aggregate(
                () => Assert.Equal(42, actualUser.UserId),
                () => Assert.Equal("John Doe", actualUser.Name));
        }
    }
}