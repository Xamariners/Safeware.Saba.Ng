using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Safeware.Saba.Ng.ChildEntities
{
    public partial interface IChildEntityRepository : IRepository<ChildEntity, Guid>
    {
        Task<List<ChildEntity>> GetListByMasterEntityIdAsync(
    Guid masterEntityId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default
);

        Task<long> GetCountByMasterEntityIdAsync(Guid masterEntityId, CancellationToken cancellationToken = default);

        Task<List<ChildEntityWithNavigationProperties>> GetListWithNavigationPropertiesByMasterEntityIdAsync(
            Guid masterEntityId,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<ChildEntityWithNavigationProperties> GetWithNavigationPropertiesAsync(
            Guid id,
            CancellationToken cancellationToken = default
        );

        Task<List<ChildEntityWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? name = null,
            bool? enabled = null,
            Guid? bookId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<List<ChildEntity>> GetListAsync(
                    string? filterText = null,
                    string? name = null,
                    bool? enabled = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            bool? enabled = null,
            Guid? bookId = null,
            CancellationToken cancellationToken = default);
    }
}