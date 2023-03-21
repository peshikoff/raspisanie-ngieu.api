using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class Преподаватели
    {
        public Преподаватели()
        {
            Мероприятияs = new HashSet<Мероприятия>();
            Предметыs = new HashSet<Предметы>();
        }

        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public string Институт { get; set; } = null!;
        public string Кафедра { get; set; } = null!;
        public string? КурируемаяГруппа { get; set; }

        public virtual Институты ИнститутNavigation { get; set; } = null!;
        public virtual Кафедры КафедраNavigation { get; set; } = null!;
        public virtual ICollection<Мероприятия> Мероприятияs { get; set; }
        public virtual ICollection<Предметы> Предметыs { get; set; }
    }
}
