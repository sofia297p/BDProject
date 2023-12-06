using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class GroupAlcoholic
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? AlcoholicId { get; set; }

        public virtual Alcoholic? Alcoholic { get; set; }
        public virtual Groupa? Group { get; set; }
    }
}
