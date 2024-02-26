using System;
using System.Collections.Generic;

namespace RedBook
{
    public partial class Genuse
    {
        public Genuse()
        {
            Species = new HashSet<Species>();
        }

        public string Title { get; set; } = null!;
        public string FamilyTitle { get; set; } = null!;

        public virtual Family FamilyTitleNavigation { get; set; } = null!;
        public virtual ICollection<Species> Species { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
