using System;
using System.Collections.Generic;

namespace RecuPj.Models
{
    public partial class Determination
    {
        public Determination()
        {
            Echantillons = new HashSet<Echantillon>();
        }

        public string Desdet { get; set; } = null!;
        public decimal? Prix { get; set; }

        public virtual ICollection<Echantillon> Echantillons { get; set; }
    }
}
