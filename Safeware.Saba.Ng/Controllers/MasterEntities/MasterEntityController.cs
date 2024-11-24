using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Safeware.Saba.Ng.MasterEntities;
using Volo.Abp.Content;
using Safeware.Saba.Ng.Shared;

namespace Safeware.Saba.Ng.MasterEntities
{
    [RemoteService]
    [Area("app")]
    [ControllerName("MasterEntity")]
    [Route("api/app/master-entities")]

    public abstract class MasterEntityControllerBase : AbpController
    {
        protected IMasterEntitiesAppService _masterEntitiesAppService;

        public MasterEntityControllerBase(IMasterEntitiesAppService masterEntitiesAppService)
        {
            _masterEntitiesAppService = masterEntitiesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<MasterEntityDto>> GetListAsync(GetMasterEntitiesInput input)
        {
            return _masterEntitiesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<MasterEntityDto> GetAsync(Guid id)
        {
            return _masterEntitiesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<MasterEntityDto> CreateAsync(MasterEntityCreateDto input)
        {
            return _masterEntitiesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<MasterEntityDto> UpdateAsync(Guid id, MasterEntityUpdateDto input)
        {
            return _masterEntitiesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _masterEntitiesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(MasterEntityExcelDownloadDto input)
        {
            return _masterEntitiesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public virtual Task<Safeware.Saba.Ng.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _masterEntitiesAppService.GetDownloadTokenAsync();
        }

        [HttpDelete]
        [Route("")]
        public virtual Task DeleteByIdsAsync(List<Guid> masterentityIds)
        {
            return _masterEntitiesAppService.DeleteByIdsAsync(masterentityIds);
        }

        [HttpDelete]
        [Route("all")]
        public virtual Task DeleteAllAsync(GetMasterEntitiesInput input)
        {
            return _masterEntitiesAppService.DeleteAllAsync(input);
        }
    }
}