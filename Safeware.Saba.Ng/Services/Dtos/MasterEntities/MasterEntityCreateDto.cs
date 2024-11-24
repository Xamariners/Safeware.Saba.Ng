using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Safeware.Saba.Ng.MasterEntities
{
    public abstract class MasterEntityCreateDtoBase
    {
        public string? Name { get; set; }
        public int Cost { get; set; } = 0;
        [Required]
        public string Address { get; set; } = null!;
    }
}