using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class Предметы
    {
        public Предметы()
        {
            Измененияs = new HashSet<Изменения>();
            Расписаниеs = new HashSet<Расписание>();
        }

        public Guid Guid { get; set; }
        public string Group { get; set; } = null!;
        public string Lesson { get; set; } = null!;
        public Guid TeacherGuid { get; set; }
        public string? ТипПары { get; set; }

        public virtual СписокГрупп GroupNavigation { get; set; } = null!;
        public virtual Преподаватели TeacherGu { get; set; } = null!;
        public virtual ТипыПар? ТипПарыNavigation { get; set; }
        public virtual ICollection<Изменения> Измененияs { get; set; }
        public virtual ICollection<Расписание> Расписаниеs { get; set; }
    }
}
