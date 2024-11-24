using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Safeware.Saba.Ng.ChildEntities
{
    public abstract class ChildEntityDtoBase : FullAuditedEntityDto<Guid>
    {
        public Guid MasterEntityId { get; set; }
        public string? Name { get; set; }
        public bool Enabled { get; set; }
        public Guid? BookId { get; set; }

    }
}