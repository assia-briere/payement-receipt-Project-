using System;
using System.Collections.Generic;

namespace RecuPj.Models
{
    public partial class Echantillon
    {
        public Echantillon()
        {
            Demandes = new HashSet<Demande>();
            Factures = new HashSet<Facture>();
        }

        public int Nlabo { get; set; }
        public string? Designation { get; set; }
        public string? Desdet { get; set; }

        public virtual Determination? DesdetNavigation { get; set; }
        public virtual ICollection<Demande> Demandes { get; set; }
        public virtual ICollection<Facture> Factures { get; set; }
    }
}
