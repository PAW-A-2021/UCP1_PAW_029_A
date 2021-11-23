using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1.Models
{
    public partial class Barang
    {
        public int IdDetailBarang { get; set; }
        public string NamaPengirim { get; set; }
        public string NamaPenerima { get; set; }
        public string NomorResiPengiriman { get; set; }
        public string AlamatPengirim { get; set; }
        public string AlamatTujuan { get; set; }
        public int? BeratBarang { get; set; }
        public int? Harga { get; set; }
        public string StatusBarang { get; set; }

        public virtual Detail Detail { get; set; }
    }
}
