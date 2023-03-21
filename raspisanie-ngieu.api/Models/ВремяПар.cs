using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class ВремяПар
    {
        public ВремяПар()
        {
            Измененияs = new HashSet<Изменения>();
            Расписаниеs = new HashSet<Расписание>();
        }

        public Guid Guid { get; set; }
        public string ВремяId { get; set; } = null!;
        public byte НомерПары { get; set; }

        public virtual ICollection<Изменения> Измененияs { get; set; }
        public virtual ICollection<Расписание> Расписаниеs { get; set; }
    }
}
