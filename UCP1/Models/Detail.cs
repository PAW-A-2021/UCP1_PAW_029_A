using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1.Models
{
    public partial class Detail
    {
        public int IdDetailBarang { get; set; }
        public string NomorResiPengiriman { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdAdministrator { get; set; }
        public int? IdKurir { get; set; }

        public virtual Administrator IdAdministratorNavigation { get; set; }
        public virtual Customer IdCustomerNavigation { get; set; }
        public virtual Barang IdDetailBarangNavigation { get; set; }
        public virtual Kurir IdKurirNavigation { get; set; }
    }
}
