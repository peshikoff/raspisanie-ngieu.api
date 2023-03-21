using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class Институты
    {
        public Институты()
        {
            Кафедрыs = new HashSet<Кафедры>();
            Преподавателиs = new HashSet<Преподаватели>();
            СписокГруппs = new HashSet<СписокГрупп>();
        }

        public Guid Guid { get; set; }
        public string Институт { get; set; } = null!;

        public virtual ICollection<Кафедры> Кафедрыs { get; set; }
        public virtual ICollection<Преподаватели> Преподавателиs { get; set; }
        public virtual ICollection<СписокГрупп> СписокГруппs { get; set; }
    }
}
