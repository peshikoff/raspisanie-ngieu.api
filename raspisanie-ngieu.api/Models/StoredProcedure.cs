using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace raspisanie_ngieu.api.Models
{
    public partial class StoredProcedureModel
    {
        public string Week { get; set; } = null!;
        public string Day { get; set; } = null!;
        
        public byte Номер_Пары { get; set; }
        public string Group { get; set; } = null!;
        
        public string Lesson { get; set; } = null!;
        
        public string Тип_Пары { get; set; } = null!;
        
        public string ФИО { get; set; } = null!;
        
        public string? Кабинет { get; set; }
    }
}
