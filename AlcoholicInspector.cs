using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class AlcoholicInspector
    {
        public int Id { get; set; }
        public int? InspectorId { get; set; }
        public int? AlcoholicId { get; set; }
        public DateTime? Date { get; set; }
        public int? State { get; set; }
        public int? BedId { get; set; }
        public virtual Bed Bed { get; set; }
        public virtual Alcoholic? Alcoholic { get; set; }
        public virtual Inspector? Inspector { get; set; }
    }
}
