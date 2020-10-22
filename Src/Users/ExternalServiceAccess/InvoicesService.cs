using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Users.Domain;
using Users.ExternalDependencies;
using Users.StorageAccess;

namespace Users.ExternalServiceAccess
{
    public class InvoicesService : IInvoicesFacade
    {
        public async Task<List<Invoice>> GetInvoicesByUserIdAsync(int userId) => 
            (await DataFile.ReadFromFileAsync<Invoice>()).Where(invoice => invoice.UserId == userId).ToList();
    }
}