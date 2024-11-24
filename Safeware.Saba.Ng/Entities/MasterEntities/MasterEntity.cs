using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Safeware.Saba.Ng.ChildEntities;

using Volo.Abp;

namespace Safeware.Saba.Ng.MasterEntities
{
    public abstract class MasterEntityBase : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? Name { get; set; }

        public virtual int Cost { get; set; }

        [NotNull]
        public virtual string Address { get; set; }

        public ICollection<ChildEntity> ChildEntities { get; private set; }

        protected MasterEntityBase()
        {

        }

        public MasterEntityBase(Guid id, int cost, string address, string? name = null)
        {

            Id = id;
            Check.NotNull(address, nameof(address));
            Cost = cost;
            Address = address;
            Name = name;
            ChildEntities = new Collection<ChildEntity>();
        }

    }
}