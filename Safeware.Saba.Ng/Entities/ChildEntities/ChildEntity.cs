using Book;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Safeware.Saba.Ng.ChildEntities
{
    public abstract class ChildEntityBase : FullAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid MasterEntityId { get; set; }

        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? Name { get; set; }

        public virtual bool Enabled { get; set; }
        public Guid? BookId { get; set; }

        protected ChildEntityBase()
        {

        }

        public ChildEntityBase(Guid id, Guid masterEntityId, Guid? bookId, bool enabled, string? name = null)
        {

            Id = id;
            MasterEntityId = masterEntityId;
            Enabled = enabled;
            Name = name;
            BookId = bookId;
        }

    }
}