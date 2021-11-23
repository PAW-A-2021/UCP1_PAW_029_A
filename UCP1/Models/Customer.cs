using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Details = new HashSet<Detail>();
        }

        public int IdCustomer { get; set; }
        public string NamaCustomer { get; set; }
        public string NomorTelepon { get; set; }
        public string Alamat { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}
