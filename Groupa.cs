using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class Groupa
    {
        public Groupa()
        {
            GroupAlcoholics = new HashSet<GroupAlcoholic>();
        }

        public int Id { get; set; }
        public string? GroupName { get; set; }

        public virtual ICollection<GroupAlcoholic> GroupAlcoholics { get; set; }
    }
}
