using System;
using System.Collections.Generic;

namespace RedBook
{
    public partial class Squad
    {
        public Squad()
        {
            Families = new HashSet<Family>();
        }

        public string Title { get; set; } = null!;
        public string ClassTitle { get; set; } = null!;

        public virtual Class ClassTitleNavigation { get; set; } = null!;
        public virtual ICollection<Family> Families { get; set; }
        public override string ToString()
        {
            return Title;
        }
    }
}
