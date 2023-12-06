﻿using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class ReleaseAlcoholicBed
    {
        public int PairId { get; set; }
        public int? BedId { get; set; }
        public DateOnly? Date { get; set; }

        public virtual Bed? Bed { get; set; }
        public virtual AlcoholicInspector AlcoholicInspector { get; set; } = null!;
    }
}