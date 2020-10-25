using System.Collections.Generic;
using System.Linq;
using Users.Domain;
using Users.StorageAccess;

namespace Users.ExternalDependencies
{
    public static class DtoConverter
    {
        public static User Convert(this UserRow userRow) => new User {UserId = userRow.UserId, Name = userRow.Name};
        public static Address Convert(this AddressRow addressRow) => new Address {StreetAddress = addressRow?.StreetAddress};

        public static List<Invoice> Convert(this List<InvoiceDto> invoiceDtos, int userId) => 
            (from dto in invoiceDtos where dto.UserId == userId select new Invoice {BillToAddress = dto.BillToAddress, InvoiceLines = dto.InvoiceLines}).ToList();
    }
}