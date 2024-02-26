using System;
using System.Collections.Generic;

namespace RedBook
{
    public partial class Family
    {
        public Family()
        {
            Genuses = new HashSet<Genuse>();
        }

        public string Title { get; set; } = null!;
        public string SquadTitle { get; set; } = null!;

        public virtual Squad SquadTitleNavigation { get; set; } = null!;
        public virtual ICollection<Genuse> Genuses { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
