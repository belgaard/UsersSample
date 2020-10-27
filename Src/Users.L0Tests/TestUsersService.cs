using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using LeanTest;
using LeanTest.Core.ExecutionHandling;
using LeanTest.Xunit;
using Users.Domain;
using Users.L0Tests.Builders;
using Users.L0Tests.Extensions;
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
            // Given aka. Arrange aka. setup initial context/state:
            _contextBuilder 
                .WithData(TestData.UserRows.JohnDoe42)
                .WithData(TestData.AddressRows.JaneDoeStreetForUser42)
                .WithData(TestData.InvoiceDtos.NoLinesForUser42)
                .Build();

            // When aka. Act aka. an event occurs:
            HttpResponseMessage actual = await _target.GetAsync("users?userId=42&includeInvoices=true");

            // Then aka. Assert aka. ensure some outcomes:
            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
            User actualUser = await actual.Deserialize<User>();
            MultiAssert.Aggregate(
                () => Assert.Equal(42, actualUser.UserId),
                () => Assert.Equal("John Doe", actualUser.Name),
                () => Assert.EndsWith("Jane Doe Street", actualUser.Address.StreetAddress),
                () => Assert.Empty(actualUser.Invoices.First().InvoiceLines));
        }

        [Fact]
        public async Task GetUserMustReturnRequestedUserWhenUserRowIsBuiltUsingABuilder() // Slightly contrived, but I wanted to show how to build a value.
        {
            const int userId = 42;
            const string userName = "John Doe";
            // Given aka. Arrange aka. setup initial context/state:
            _contextBuilder 
                .WithData(new UserRowBuilder().WithUserId(userId).WithName(userName).Build())
                .Build();

            // When aka. Act aka. an event occurs:
            HttpResponseMessage actual = await _target.GetAsync($"users?userId={userId}&includeInvoices=true");

            // Then aka. Assert aka. ensure some outcomes:
            Assert.Equal(HttpStatusCode.OK, actual.StatusCode);
            User actualUser = await actual.Deserialize<User>();
            MultiAssert.Aggregate(
                () => Assert.Equal(userId, actualUser.UserId),
                () => Assert.Equal(userName, actualUser.Name));
        }
    }
}