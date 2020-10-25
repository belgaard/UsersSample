using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.StorageAccess;

namespace Users.ExternalDependencies
{
    public class InvoicesService : IInvoicesFacade
    {
        public async Task<List<InvoiceDto>> GetInvoicesByUserIdAsync(int userId) => 
            (await DataFile.ReadFromFileAsync<InvoiceDto>()).Where(invoice => invoice.UserId == userId).ToList();
    }
}