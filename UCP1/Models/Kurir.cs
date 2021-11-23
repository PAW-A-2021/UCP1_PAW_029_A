using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1.Models
{
    public partial class Kurir
    {
        public Kurir()
        {
            Details = new HashSet<Detail>();
        }

        public int IdKurir { get; set; }
        public string NamaKurir { get; set; }
        public string NomorTelepon { get; set; }
        public int IdPerusahaan { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}
