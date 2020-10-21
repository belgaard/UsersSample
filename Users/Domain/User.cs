using System.Collections.Generic;

namespace Users.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public List<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}
