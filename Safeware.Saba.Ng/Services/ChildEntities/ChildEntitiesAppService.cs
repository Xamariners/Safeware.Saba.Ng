using Safeware.Saba.Ng.Shared;
using Book;
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Safeware.Saba.Ng.Permissions;
using Safeware.Saba.Ng.ChildEntities;

namespace Safeware.Saba.Ng.ChildEntities
{
    [RemoteService(IsEnabled = false)]
    [Authorize(NgPermissions.ChildEntities.Default)]
    public abstract class ChildEntitiesAppServiceBase : ApplicationService
    {

        protected IChildEntityRepository _childEntityRepository;
        protected ChildEntityManager _childEntityManager;

        protected IRepository<Book.Book, Guid> _bookRepository;

        public ChildEntitiesAppServiceBase(IChildEntityRepository childEntityRepository, ChildEntityManager childEntityManager, IRepository<Book.Book, Guid> bookRepository)
        {

            _childEntityRepository = childEntityRepository;
            _childEntityManager = childEntityManager; _bookRepository = bookRepository;

        }

        public virtual async Task<PagedResultDto<ChildEntityDto>> GetListByMasterEntityIdAsync(GetChildEntityListInput input)
        {
            var childEntities = await _childEntityRepository.GetListByMasterEntityIdAsync(
                input.MasterEntityId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<ChildEntityDto>
            {
                TotalCount = await _childEntityRepository.GetCountByMasterEntityIdAsync(input.MasterEntityId),
                Items = ObjectMapper.Map<List<ChildEntity>, List<ChildEntityDto>>(childEntities)
            };
        }
        public virtual async Task<PagedResultDto<ChildEntityWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByMasterEntityIdAsync(GetChildEntityListInput input)
        {
            var childEntities = await _childEntityRepository.GetListWithNavigationPropertiesByMasterEntityIdAsync(
                input.MasterEntityId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<ChildEntityWithNavigationPropertiesDto>
            {
                TotalCount = await _childEntityRepository.GetCountByMasterEntityIdAsync(input.MasterEntityId),
                Items = ObjectMapper.Map<List<ChildEntityWithNavigationProperties>, List<ChildEntityWithNavigationPropertiesDto>>(childEntities)
            };
        }

        public virtual async Task<PagedResultDto<ChildEntityWithNavigationPropertiesDto>> GetListAsync(GetChildEntitiesInput input)
        {
            var totalCount = await _childEntityRepository.GetCountAsync(input.FilterText, input.Name, input.Enabled, input.BookId);
            var items = await _childEntityRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Name, input.Enabled, input.BookId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ChildEntityWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ChildEntityWithNavigationProperties>, List<ChildEntityWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<ChildEntityWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<ChildEntityWithNavigationProperties, ChildEntityWithNavigationPropertiesDto>
                (await _childEntityRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ChildEntityDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ChildEntity, ChildEntityDto>(await _childEntityRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetBookLookupAsync(LookupRequestDto input)
        {
            var query = (await _bookRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Book.Book>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Book.Book>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(NgPermissions.ChildEntities.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _childEntityRepository.DeleteAsync(id);
        }

        [Authorize(NgPermissions.ChildEntities.Create)]
        public virtual async Task<ChildEntityDto> CreateAsync(ChildEntityCreateDto input)
        {

            var childEntity = await _childEntityManager.CreateAsync(input.MasterEntityId
            , input.BookId, input.Enabled, input.Name
            );

            return ObjectMapper.Map<ChildEntity, ChildEntityDto>(childEntity);
        }

        [Authorize(NgPermissions.ChildEntities.Edit)]
        public virtual async Task<ChildEntityDto> UpdateAsync(Guid id, ChildEntityUpdateDto input)
        {

            var childEntity = await _childEntityManager.UpdateAsync(
            id, input.MasterEntityId
            , input.BookId, input.Enabled, input.Name
            );

            return ObjectMapper.Map<ChildEntity, ChildEntityDto>(childEntity);
        }
    }
}