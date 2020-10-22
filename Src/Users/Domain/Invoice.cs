using System.Collections.Generic;
using Users.ExternalDependencies;

namespace Users.Domain
{
    public class Invoice
    {
        public List<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
        public BillToAddress BillToAddress { get; set; }
    }
}