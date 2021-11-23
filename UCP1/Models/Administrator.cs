using System;
using System.Collections.Generic;

#nullable disable

namespace UCP1.Models
{
    public partial class Administrator
    {
        public Administrator()
        {
            Details = new HashSet<Detail>();
        }

        public int IdAdministrator { get; set; }
        public string NamaAdministrator { get; set; }
        public string NomorTelepon { get; set; }
        public int IdPerusahaan { get; set; }

        public virtual ICollection<Detail> Details { get; set; }
    }
}
