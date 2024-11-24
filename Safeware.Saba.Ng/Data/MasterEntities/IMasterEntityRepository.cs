using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Safeware.Saba.Ng.MasterEntities
{
    public partial interface IMasterEntityRepository : IRepository<MasterEntity, Guid>
    {

        Task DeleteAllAsync(
            string? filterText = null,
            string? name = null,
            int? costMin = null,
            int? costMax = null,
            string? address = null,
            CancellationToken cancellationToken = default);
        Task<List<MasterEntity>> GetListAsync(
                    string? filterText = null,
                    string? name = null,
                    int? costMin = null,
                    int? costMax = null,
                    string? address = null,
                    string? sorting = null,
                    int maxResultCount = int.MaxValue,
                    int skipCount = 0,
                    CancellationToken cancellationToken = default
                );

        Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            int? costMin = null,
            int? costMax = null,
            string? address = null,
            CancellationToken cancellationToken = default);
    }
}