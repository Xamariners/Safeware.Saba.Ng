using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Safeware.Saba.Ng.ChildEntities
{
    public abstract class ChildEntityManagerBase : DomainService
    {
        protected IChildEntityRepository _childEntityRepository;

        public ChildEntityManagerBase(IChildEntityRepository childEntityRepository)
        {
            _childEntityRepository = childEntityRepository;
        }

        public virtual async Task<ChildEntity> CreateAsync(
        Guid masterEntityId, Guid? bookId, bool enabled, string? name = null)
        {

            var childEntity = new ChildEntity(
             GuidGenerator.Create(),
             masterEntityId, bookId, enabled, name
             );

            return await _childEntityRepository.InsertAsync(childEntity);
        }

        public virtual async Task<ChildEntity> UpdateAsync(
            Guid id,
            Guid masterEntityId, Guid? bookId, bool enabled, string? name = null
        )
        {

            var childEntity = await _childEntityRepository.GetAsync(id);

            childEntity.MasterEntityId = masterEntityId;
            childEntity.BookId = bookId;
            childEntity.Enabled = enabled;
            childEntity.Name = name;

            return await _childEntityRepository.UpdateAsync(childEntity);
        }

    }
}