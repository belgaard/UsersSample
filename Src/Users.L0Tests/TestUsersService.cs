using System.Linq;
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
    }

    internal static class HttpResponseMessageExtensions
    {
        internal static async Task<T> Deserialize<T>(this HttpResponseMessage message) => 
            JsonSerializer.Deserialize<T>(await message.Content.ReadAsStringAsync(), new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
    }
}