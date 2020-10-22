using System.Collections.Generic;
using Users.Domain;
using Users.ExternalDependencies;

namespace Users.ExternalServiceAccess
{
    public class InvoiceDto
    {
        public int UserId { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
        public BillToAddress BillToAddress { get; set; }
    }
}