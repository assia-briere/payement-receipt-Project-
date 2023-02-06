using System;
using System.Collections.Generic;

namespace RecuPj.Models
{
    public partial class Facture
    {
        public Facture()
        {
            Recus = new HashSet<Recu>();
        }

        public int Nfacture { get; set; }
        public string? Demandeur { get; set; }
        public string? Payeur { get; set; }
        public DateTime? Date { get; set; }
        public int? Nlabo { get; set; }

        public virtual Echantillon? NlaboNavigation { get; set; }
        public virtual ICollection<Recu> Recus { get; set; }
    }
}
