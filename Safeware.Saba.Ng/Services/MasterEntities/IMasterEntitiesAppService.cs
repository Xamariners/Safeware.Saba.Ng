using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using Safeware.Saba.Ng.Shared;

namespace Safeware.Saba.Ng.MasterEntities
{
    public partial interface IMasterEntitiesAppService : IApplicationService
    {

        Task<PagedResultDto<MasterEntityDto>> GetListAsync(GetMasterEntitiesInput input);

        Task<MasterEntityDto> GetAsync(Guid id);

        Task DeleteAsync(Guid id);

        Task<MasterEntityDto> CreateAsync(MasterEntityCreateDto input);

        Task<MasterEntityDto> UpdateAsync(Guid id, MasterEntityUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(MasterEntityExcelDownloadDto input);
        Task DeleteByIdsAsync(List<Guid> masterentityIds);

        Task DeleteAllAsync(GetMasterEntitiesInput input);
        Task<Safeware.Saba.Ng.Shared.DownloadTokenResultDto> GetDownloadTokenAsync();

    }
}