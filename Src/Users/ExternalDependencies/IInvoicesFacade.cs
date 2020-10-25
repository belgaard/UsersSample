using System.Collections.Generic;
using System.Threading.Tasks;

namespace Users.ExternalDependencies
{
    public interface IInvoicesFacade
    {
        Task<List<InvoiceDto>> GetInvoicesByUserIdAsync(int userId);
    }
}