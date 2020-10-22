using System.Collections.Generic;
using System.Threading.Tasks;
using Users.Domain;

namespace Users.ExternalDependencies
{
    public interface IInvoicesFacade
    {
        Task<List<Invoice>> GetInvoicesByUserIdAsync(int userId);
    }
}