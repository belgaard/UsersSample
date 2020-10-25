using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LeanTest.Mock;
using Users.ExternalDependencies;

namespace Users.L0Tests.Mocks
{
    public class MockForDataInvoicesFacade : IInvoicesFacade, IMockForData<InvoiceDto>
    {
        private readonly List<InvoiceDto> _invoices = new List<InvoiceDto>();

        public async Task<List<InvoiceDto>> GetInvoicesByUserIdAsync(int userId) => await Task.FromResult(_invoices);
        public void WithData(InvoiceDto data) => _invoices.Add(data);

        public void PreBuild() {}
        public void Build(Type type) {}
        public void PostBuild() {}
    }
}