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
using Safeware.Saba.Ng.MasterEntities;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Safeware.Saba.Ng.Shared;

namespace Safeware.Saba.Ng.MasterEntities
{
    [RemoteService(IsEnabled = false)]
    [Authorize(NgPermissions.MasterEntities.Default)]
    public abstract class MasterEntitiesAppServiceBase : ApplicationService
    {
        protected IDistributedCache<MasterEntityDownloadTokenCacheItem, string> _downloadTokenCache;
        protected IMasterEntityRepository _masterEntityRepository;
        protected MasterEntityManager _masterEntityManager;

        public MasterEntitiesAppServiceBase(IMasterEntityRepository masterEntityRepository, MasterEntityManager masterEntityManager, IDistributedCache<MasterEntityDownloadTokenCacheItem, string> downloadTokenCache)
        {
            _downloadTokenCache = downloadTokenCache;
            _masterEntityRepository = masterEntityRepository;
            _masterEntityManager = masterEntityManager;

        }

        public virtual async Task<PagedResultDto<MasterEntityDto>> GetListAsync(GetMasterEntitiesInput input)
        {
            var totalCount = await _masterEntityRepository.GetCountAsync(input.FilterText, input.Name, input.CostMin, input.CostMax, input.Address);
            var items = await _masterEntityRepository.GetListAsync(input.FilterText, input.Name, input.CostMin, input.CostMax, input.Address, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<MasterEntityDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<MasterEntity>, List<MasterEntityDto>>(items)
            };
        }

        public virtual async Task<MasterEntityDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<MasterEntity, MasterEntityDto>(await _masterEntityRepository.GetAsync(id));
        }

        [Authorize(NgPermissions.MasterEntities.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _masterEntityRepository.DeleteAsync(id);
        }

        [Authorize(NgPermissions.MasterEntities.Create)]
        public virtual async Task<MasterEntityDto> CreateAsync(MasterEntityCreateDto input)
        {

            var masterEntity = await _masterEntityManager.CreateAsync(
            input.Cost, input.Address, input.Name
            );

            return ObjectMapper.Map<MasterEntity, MasterEntityDto>(masterEntity);
        }

        [Authorize(NgPermissions.MasterEntities.Edit)]
        public virtual async Task<MasterEntityDto> UpdateAsync(Guid id, MasterEntityUpdateDto input)
        {

            var masterEntity = await _masterEntityManager.UpdateAsync(
            id,
            input.Cost, input.Address, input.Name, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<MasterEntity, MasterEntityDto>(masterEntity);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(MasterEntityExcelDownloadDto input)
        {
            var downloadToken = await _downloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _masterEntityRepository.GetListAsync(input.FilterText, input.Name, input.CostMin, input.CostMax, input.Address);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<MasterEntity>, List<MasterEntityExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "MasterEntities.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [Authorize(NgPermissions.MasterEntities.Delete)]
        public virtual async Task DeleteByIdsAsync(List<Guid> masterentityIds)
        {
            await _masterEntityRepository.DeleteManyAsync(masterentityIds);
        }

        [Authorize(NgPermissions.MasterEntities.Delete)]
        public virtual async Task DeleteAllAsync(GetMasterEntitiesInput input)
        {
            await _masterEntityRepository.DeleteAllAsync(input.FilterText, input.Name, input.CostMin, input.CostMax, input.Address);
        }
        public virtual async Task<Safeware.Saba.Ng.Shared.DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _downloadTokenCache.SetAsync(
                token,
                new MasterEntityDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new Safeware.Saba.Ng.Shared.DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}