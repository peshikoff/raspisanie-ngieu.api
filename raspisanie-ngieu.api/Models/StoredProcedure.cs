using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace raspisanie_ngieu.api.Models
{
    public partial class StoredProcedureModel
    {
        public string Day { get; set; } = null!;

        public byte Number { get; set; }
        public string Time { get; set; } = null!;
        public string Group { get; set; } = null!;
        public string Lesson { get; set; } = null!;
        
        public string? Type { get; set; } = null!;

        public string? FIO { get; set; } = null!;

        public string? Room { get; set; } = null!;
    }
}
