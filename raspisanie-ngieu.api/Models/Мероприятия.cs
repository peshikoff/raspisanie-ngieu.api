using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class Мероприятия
    {
        public Guid Guid { get; set; }
        public string Group { get; set; } = null!;
        public string Event { get; set; } = null!;
        public Guid TeacherGuid { get; set; }

        public virtual СписокГрупп GroupNavigation { get; set; } = null!;
        public virtual Преподаватели TeacherGu { get; set; } = null!;
    }
}
