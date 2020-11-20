using LeanTest;
using LeanTest.Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Users.L0Tests.TestSetup;
using Users.L0Tests.TestSetup.IoC;

[assembly: AssemblyFixture(typeof(AssemblyInitializer))]
[assembly: Xunit.TestFramework("LeanTest.Xunit.XunitExtensions.XunitTestFrameworkWithAssemblyFixture", "LeanTest.Xunit")]

namespace Users.L0Tests.TestSetup
{
    /// <summary>Does the setup which must must be done consistently across all tests in the assembly.</summary>
    public sealed class AssemblyInitializer
    {
        public AssemblyInitializer()
        {
            // The .NET Core web application factory is documented here
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.testing.webapplicationfactory-1?view=aspnetcore-3.0&viewFallbackFrom=aspnetcore-3.1
            static WebApplicationFactory<Startup> FactoryFactory()
            {
                var factory = new WebApplicationFactory<Startup>();
                factory = factory.WithWebHostBuilder(builder =>
                    builder
                        .ConfigureTestServices(L0CompositionRootForTest.Initialize));
 
                return factory;
            }
            AspNetCoreContextBuilderFactory.Initialize(FactoryFactory, provider => new IocContainer(provider));
        }
    }
}