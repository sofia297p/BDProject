using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class PutAlcoholicBed
    {
        public int PairId { get; set; }
        public int? BedId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Bed? Bed { get; set; }
        public virtual AlcoholicInspector AlcoholicInspector { get; set; } = null!;
    }
}
