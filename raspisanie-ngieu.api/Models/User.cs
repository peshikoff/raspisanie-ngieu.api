using System;
using System.Collections.Generic;

namespace raspisanie_ngieu.api.Models
{
    public partial class User
    {
        public Guid Guid { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string? Patronymic { get; set; }
        public byte[]? Photo { get; set; }
        public string? Group { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual СписокГрупп? GroupNavigation { get; set; }
    }
}
