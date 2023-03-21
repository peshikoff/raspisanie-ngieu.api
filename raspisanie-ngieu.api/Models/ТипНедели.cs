using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class ТипНедели
    {
        public ТипНедели()
        {
            Измененияs = new HashSet<Изменения>();
            Расписаниеs = new HashSet<Расписание>();
        }

        public Guid Guid { get; set; }
        public string ТипНедели1 { get; set; } = null!;

        public virtual ICollection<Изменения> Измененияs { get; set; }
        public virtual ICollection<Расписание> Расписаниеs { get; set; }
    }
}
