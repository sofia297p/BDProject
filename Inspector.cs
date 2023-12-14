using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class Inspector
    {
        public Inspector()
        {
            AlcoholicInspectors = new HashSet<AlcoholicInspector>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual Person? User { get; set; }
        public virtual ICollection<AlcoholicInspector> AlcoholicInspectors { get; set; }
    }
}
