using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class DrinkProcess
    {
        public int Id { get; set; }
        public int? GroupAlcoholicId { get; set; }
        public DateTime? Date { get; set; }
        public int? DrinkTypeId { get; set; }
    }
}
