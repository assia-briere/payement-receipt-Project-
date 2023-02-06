using System;
using System.Collections.Generic;

namespace RecuPj.Models
{
    public partial class Banque
    {
        public Banque()
        {
            Cheques = new HashSet<Cheque>();
        }

        public string Na { get; set; } = null!;
        public string? Nom { get; set; }
        public DateTime? DateCreation { get; set; }

        public virtual ICollection<Cheque> Cheques { get; set; }
    }
}
