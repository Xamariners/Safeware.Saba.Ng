using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Safeware.Saba.Ng.MasterEntities
{
    public abstract class MasterEntityUpdateDtoBase : IHasConcurrencyStamp
    {
        public string? Name { get; set; }
        public int Cost { get; set; }
        [Required]
        public string Address { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;
    }
}