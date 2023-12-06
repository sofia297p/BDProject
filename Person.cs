using System;
using System.Collections.Generic;

namespace Sanatorium
{
    public partial class Person
    {
        public Person()
        {
            Alcoholics = new HashSet<Alcoholic>();
            Inspectors = new HashSet<Inspector>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? Sex { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<Alcoholic> Alcoholics { get; set; }
        public virtual ICollection<Inspector> Inspectors { get; set; }
    }
}
