using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class ТипыПар
    {
        public ТипыПар()
        {
            Предметыs = new HashSet<Предметы>();
        }

        public Guid Guid { get; set; }
        public string ТипПарыId { get; set; } = null!;

        public virtual ICollection<Предметы> Предметыs { get; set; }
    }
}
