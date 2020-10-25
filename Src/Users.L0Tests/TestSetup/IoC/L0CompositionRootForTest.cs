using LeanTest.Mock;
using Microsoft.Extensions.DependencyInjection;
using Users.ExternalDependencies;
using Users.L0Tests.Mocks;
using Users.StorageAccess;

namespace Users.L0Tests.TestSetup.IoC
{
    public static class L0CompositionRootForTest
    {
        public static void Initialize(IServiceCollection serviceCollection)
        {
            // Mock-for-data:
            serviceCollection.RegisterMockForData<IUsersStorageFacade, MockForDataUsersStorageFacade, UserRow, AddressRow>();
            serviceCollection.RegisterMockForData<IInvoicesFacade, MockForDataInvoicesFacade, InvoiceDto>();
        }

        private static void RegisterMockForData<TInterface, TImplementation, TData>(this IServiceCollection container) 
            where TImplementation: class, TInterface, IMockForData<TData>
            where TInterface: class
        {
            container.AddSingleton<TImplementation>();
            container.AddSingleton<TInterface>(x => x.GetRequiredService<TImplementation>());
            container.AddSingleton<IMockForData<TData>>(x => x.GetRequiredService<TImplementation>());
        }

        private static void RegisterMockForData<TInterface, TImplementation, TData1, TData2>(this IServiceCollection container) 
            where TImplementation: class, TInterface, IMockForData<TData1>, IMockForData<TData2>
            where TInterface: class
        {
            container.AddSingleton<TImplementation>();
            container.AddSingleton<TInterface>(x => x.GetRequiredService<TImplementation>());
            container.AddSingleton<IMockForData<TData1>>(x => x.GetRequiredService<TImplementation>());
            container.AddSingleton<IMockForData<TData2>>(x => x.GetRequiredService<TImplementation>());
        }
    }
}