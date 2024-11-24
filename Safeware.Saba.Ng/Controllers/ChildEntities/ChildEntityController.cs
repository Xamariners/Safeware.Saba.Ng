using Safeware.Saba.Ng.Shared;
using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Safeware.Saba.Ng.ChildEntities;

namespace Safeware.Saba.Ng.ChildEntities
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ChildEntity")]
    [Route("api/app/child-entities")]

    public abstract class ChildEntityControllerBase : AbpController
    {
        protected IChildEntitiesAppService _childEntitiesAppService;

        public ChildEntityControllerBase(IChildEntitiesAppService childEntitiesAppService)
        {
            _childEntitiesAppService = childEntitiesAppService;
        }

        [HttpGet]
        [Route("by-master-entity")]
        public virtual Task<PagedResultDto<ChildEntityDto>> GetListByMasterEntityIdAsync(GetChildEntityListInput input)
        {
            return _childEntitiesAppService.GetListByMasterEntityIdAsync(input);
        }
        [HttpGet]
        [Route("detailed/by-master-entity")]
        public virtual Task<PagedResultDto<ChildEntityWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByMasterEntityIdAsync(GetChildEntityListInput input)
        {
            return _childEntitiesAppService.GetListWithNavigationPropertiesByMasterEntityIdAsync(input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ChildEntityWithNavigationPropertiesDto>> GetListAsync(GetChildEntitiesInput input)
        {
            return _childEntitiesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<ChildEntityWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _childEntitiesAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ChildEntityDto> GetAsync(Guid id)
        {
            return _childEntitiesAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("book-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetBookLookupAsync(LookupRequestDto input)
        {
            return _childEntitiesAppService.GetBookLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<ChildEntityDto> CreateAsync(ChildEntityCreateDto input)
        {
            return _childEntitiesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ChildEntityDto> UpdateAsync(Guid id, ChildEntityUpdateDto input)
        {
            return _childEntitiesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _childEntitiesAppService.DeleteAsync(id);
        }
    }
}