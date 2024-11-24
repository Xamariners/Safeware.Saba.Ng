using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Safeware.Saba.Ng.MasterEntities
{
    public abstract class MasterEntityDtoBase : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string? Name { get; set; }
        public int Cost { get; set; }
        public string Address { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;

    }
}