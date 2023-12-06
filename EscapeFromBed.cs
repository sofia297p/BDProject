using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class EscapeFromBed
    {
        public int Id { get; set; }
        public int? AlcoholicId { get; set; }
        public int? BedId { get; set; }
        public DateTime? Date { get; set; }

        public virtual Alcoholic? Alcoholic { get; set; }
        public virtual Bed? Bed { get; set; }
    }
}
