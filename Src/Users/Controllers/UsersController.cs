using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Domain;
using Users.ExternalDependencies;
using Users.StorageAccess;

namespace Users.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersStorageFacade _usersStorage;
        private readonly IInvoicesFacade _invoices;

        public UsersController(IUsersStorageFacade usersStorage, IInvoicesFacade invoices)
        {
            _usersStorage = usersStorage;
            _invoices = invoices;
        }

        /// <summary>Gets information on a user, including any associated invoices if requested.</summary>
        /// <param name="userId">The ID of the requested user.</param>
        /// <param name="includeInvoices">True if any associated invoices must be included; otherwise, false.</param>
        /// <returns>The requested user if found; otherwise, a NotFound status code.</returns>
        [HttpGet]
        [Produces(typeof(User))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        public async Task<ActionResult<User>> Get(int userId, bool includeInvoices)
        {
            if (userId <= 0)
                return UnprocessableEntity();

            UserRow userRow = await _usersStorage.GetUserByIdAsync(userId);
            if (userRow == null) 
                return NotFound();
            User user = userRow.Convert();

            user.Address = (await _usersStorage.GetAddressByUserIdAsync(userId)).Convert();

            if (!includeInvoices) 
                return user;
            user.Invoices = (await _invoices.GetInvoicesByUserIdAsync(userId)).Convert(userId);

            return user;
        }
    }
}
