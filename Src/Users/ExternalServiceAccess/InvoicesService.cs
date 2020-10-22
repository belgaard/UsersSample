using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.ExternalDependencies;
using Users.StorageAccess;

namespace Users.ExternalServiceAccess
{
    public class InvoicesService : IInvoicesFacade
    {
        public async Task<List<InvoiceDto>> GetInvoicesByUserIdAsync(int userId) => 
            (await DataFile.ReadFromFileAsync<InvoiceDto>()).Where(invoice => invoice.UserId == userId).ToList();
    }
}