using System;
using System.Collections.Generic;

namespace RedBook
{
    public partial class Species
    {
        public string Title { get; set; } = null!;
        public string GenusTitle { get; set; } = null!;
        public string? Distribution { get; set; }
        public string? Habitat { get; set; }
        public string? Count { get; set; }
        public string? Protection { get; set; }
        public string? Category { get; set; }

        public virtual Genuse GenusTitleNavigation { get; set; } = null!;
        public override string ToString()
        {
            return Title;
        }
    }
}
