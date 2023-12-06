using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class Bed
    {
        public Bed()
        {
            EscapeFromBeds = new HashSet<EscapeFromBed>();
            PutAlcoholicBeds = new HashSet<PutAlcoholicBed>();
            ReleaseAlcoholicBeds = new HashSet<ReleaseAlcoholicBed>();
        }

        public int Id { get; set; }
        public int? Number { get; set; }

        public virtual ICollection<EscapeFromBed> EscapeFromBeds { get; set; }
        public virtual ICollection<PutAlcoholicBed> PutAlcoholicBeds { get; set; }
        public virtual ICollection<ReleaseAlcoholicBed> ReleaseAlcoholicBeds { get; set; }
    }
}
