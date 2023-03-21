using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class СписокГрупп
    {
        public СписокГрупп()
        {
            Users = new HashSet<User>();
            Измененияs = new HashSet<Изменения>();
            Мероприятияs = new HashSet<Мероприятия>();
            Предметыs = new HashSet<Предметы>();
            Расписаниеs = new HashSet<Расписание>();
        }

        public Guid Guid { get; set; }
        public string Group { get; set; } = null!;
        public string Институт { get; set; } = null!;
        public byte КоличествоЧеловек { get; set; }

        public virtual Институты ИнститутNavigation { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Изменения> Измененияs { get; set; }
        public virtual ICollection<Мероприятия> Мероприятияs { get; set; }
        public virtual ICollection<Предметы> Предметыs { get; set; }
        public virtual ICollection<Расписание> Расписаниеs { get; set; }
    }
}
