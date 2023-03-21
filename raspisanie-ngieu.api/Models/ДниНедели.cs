using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class ДниНедели
    {
        public ДниНедели()
        {
            Измененияs = new HashSet<Изменения>();
            Расписаниеs = new HashSet<Расписание>();
        }

        public Guid Guid { get; set; }
        public byte НомерДня { get; set; }
        public string НазваниеДня { get; set; } = null!;

        public virtual ICollection<Изменения> Измененияs { get; set; }
        public virtual ICollection<Расписание> Расписаниеs { get; set; }
    }
}
