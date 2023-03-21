using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class Расписание
    {
        public Guid Guid { get; set; }
        public string Week { get; set; } = null!;
        public string Day { get; set; } = null!;
        public string Time { get; set; } = null!;
        public string Group { get; set; } = null!;
        public Guid? LessonGuid { get; set; }
        public string? Кабинет { get; set; }

        public virtual ДниНедели DayNavigation { get; set; } = null!;
        public virtual СписокГрупп GroupNavigation { get; set; } = null!;
        public virtual Предметы? LessonGu { get; set; }
        public virtual ВремяПар TimeNavigation { get; set; } = null!;
        public virtual ТипНедели WeekNavigation { get; set; } = null!;
        public virtual Кабинеты? КабинетNavigation { get; set; }
    }
}
