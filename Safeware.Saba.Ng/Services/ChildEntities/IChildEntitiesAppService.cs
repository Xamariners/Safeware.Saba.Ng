using Safeware.Saba.Ng.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Safeware.Saba.Ng.ChildEntities
{
    public partial interface IChildEntitiesAppService : IApplicationService
    {

        Task<PagedResultDto<ChildEntityDto>> GetListByMasterEntityIdAsync(GetChildEntityListInput input);
        Task<PagedResultDto<ChildEntityWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByMasterEntityIdAsync(GetChildEntityListInput input);

        Task<PagedResultDto<ChildEntityWithNavigationPropertiesDto>> GetListAsync(GetChildEntitiesInput input);

        Task<ChildEntityWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id);

        Task<ChildEntityDto> GetAsync(Guid id);

        Task<PagedResultDto<LookupDto<Guid>>> GetBookLookupAsync(LookupRequestDto input);

        Task DeleteAsync(Guid id);

        Task<ChildEntityDto> CreateAsync(ChildEntityCreateDto input);

        Task<ChildEntityDto> UpdateAsync(Guid id, ChildEntityUpdateDto input);
    }
}