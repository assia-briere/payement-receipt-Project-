using System;
using System.Collections.Generic;

namespace RecuPj.Models
{
    public partial class Cheque
    {
        public Cheque()
        {
            Recus = new HashSet<Recu>();
        }

        public int Ncheque { get; set; }
        public string? MontantLettre { get; set; }
        public decimal? MontantChiffres { get; set; }
        public DateTime? Date { get; set; }
        public string? Lieu { get; set; }
        public string? Beneficiare { get; set; }
        public string? Banque { get; set; }

        public virtual Banque? BanqueNavigation { get; set; }
        public virtual ICollection<Recu> Recus { get; set; }
    }
}
