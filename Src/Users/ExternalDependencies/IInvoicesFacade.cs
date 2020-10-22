using System.Collections.Generic;
using System.Threading.Tasks;
using Users.ExternalServiceAccess;

namespace Users.ExternalDependencies
{
    public interface IInvoicesFacade
    {
        Task<List<InvoiceDto>> GetInvoicesByUserIdAsync(int userId);
    }
}