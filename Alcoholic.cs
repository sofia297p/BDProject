using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class Alcoholic
    {
        public Alcoholic()
        {
            AlcoholicInspectors = new HashSet<AlcoholicInspector>();
            GroupAlcoholics = new HashSet<GroupAlcoholic>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool? Consciousness { get; set; }

        public virtual Person? User { get; set; }
        public virtual ICollection<AlcoholicInspector> AlcoholicInspectors { get; set; }
        public virtual ICollection<GroupAlcoholic> GroupAlcoholics { get; set; }
    }
}
