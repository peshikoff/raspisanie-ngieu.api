using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class Кафедры
    {
        public Кафедры()
        {
            Преподавателиs = new HashSet<Преподаватели>();
        }

        public Guid Guid { get; set; }
        public string Кафедра { get; set; } = null!;
        public string Институт { get; set; } = null!;

        public virtual Институты ИнститутNavigation { get; set; } = null!;
        public virtual ICollection<Преподаватели> Преподавателиs { get; set; }
    }
}
