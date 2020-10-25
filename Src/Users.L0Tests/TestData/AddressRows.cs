using System.Collections.Generic;
using Users.Domain;
using Users.ExternalDependencies;
using Users.StorageAccess;

namespace Users.L0Tests.TestData
{
    public static class AddressRows
    {
        public static AddressRow JaneDoeStreetForUser42 { get; } = new AddressRow {UserId = 42, StreetAddress = "4711 Jane Doe Street"};
    }
    public static class InvoiceDtos
    {
        public static InvoiceDto NoLinesForUser42 { get; } = new InvoiceDto {UserId = 42, InvoiceLines = new List<InvoiceLine>()};
    }
}
