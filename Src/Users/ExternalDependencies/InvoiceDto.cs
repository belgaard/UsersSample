﻿using System.Collections.Generic;
using Users.Domain;

namespace Users.ExternalDependencies
{
    public class InvoiceDto
    {
        public int UserId { get; set; }
        public List<InvoiceLine> InvoiceLines { get; set; } = new List<InvoiceLine>();
        public BillToAddress BillToAddress { get; set; }
    }
}