using System;
using System.Collections.Generic;

namespace RedBook
{
    public partial class Class
    {
        public Class()
        {
            Squads = new HashSet<Squad>();
        }

        public string Title { get; set; } = null!;

        public virtual ICollection<Squad> Squads { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
