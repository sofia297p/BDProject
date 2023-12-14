using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class Bed
    {
        public Bed()
        {
        }

        public int Id { get; set; }
        public int? Number { get; set; }
        public virtual ICollection<AlcoholicInspector> AlcoholicInspectors { get; set; }

    }
}
