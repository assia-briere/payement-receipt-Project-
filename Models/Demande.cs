using System;
using System.Collections.Generic;

namespace RecuPj.Models
{
    public partial class Demande
    {
        public Demande()
        {
            Recus = new HashSet<Recu>();
        }

        public int Ndum { get; set; }
        public string? Demandeur { get; set; }
        public DateTime? Date { get; set; }
        public int? Nlabo { get; set; }

        public virtual Echantillon? NlaboNavigation { get; set; }
        public virtual ICollection<Recu> Recus { get; set; }
    }
}
