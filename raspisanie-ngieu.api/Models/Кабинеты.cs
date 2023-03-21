using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class Кабинеты
    {
        public Кабинеты()
        {
            Измененияs = new HashSet<Изменения>();
            Расписаниеs = new HashSet<Расписание>();
        }

        public Guid Guid { get; set; }
        public string КабинетNo { get; set; } = null!;
        public byte КоличествоМест { get; set; }

        public virtual ICollection<Изменения> Измененияs { get; set; }
        public virtual ICollection<Расписание> Расписаниеs { get; set; }
    }
}
