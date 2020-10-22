using System.Net.Http;
using System.Threading.Tasks;
using LeanTest;
using LeanTest.Core.ExecutionHandling;
using LeanTest.Xunit;
using Users.StorageAccess;
using Xunit;
using Xunit.Abstractions;

namespace Users.L0Tests
{
    public class UnitTest1
    {
        private readonly ContextBuilder _contextBuilder;
        private readonly HttpClient _target;

        public UnitTest1(ITestOutputHelper output)
        {
            var testContext = new TestContext(output);
            _contextBuilder = ContextBuilderFactory.CreateContextBuilder()
                .RegisterAttributes(testContext)
                .Build();
            _target = _contextBuilder.GetHttpClient();
        }

        [Fact]
        public async Task Test1()
        {
            _contextBuilder
                .WithData(new UserRow {UserId = 42, Name = "Jon Doe"})
                .Build();

            var actual = await _target.GetAsync("users?userId=42");
        }
    }
}