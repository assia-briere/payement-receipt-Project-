using System;
using System.Collections.Generic;

namespace RecuPj.Models
{
    public partial class Recu
    {
        public int Nemuro { get; set; }
        public DateTime? Date { get; set; }
        public string? ModePaiement { get; set; }
        public int? Ndum { get; set; }
        public int? Nf { get; set; }
        public string? Payeur { get; set; }
        public int? Nc { get; set; }

        public virtual Cheque? NcNavigation { get; set; }
        public virtual Demande? NdumNavigation { get; set; }
        public virtual Facture? NfNavigation { get; set; }
    }
}
