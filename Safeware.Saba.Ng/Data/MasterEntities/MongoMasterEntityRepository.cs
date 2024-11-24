using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Safeware.Saba.Ng.Data;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace Safeware.Saba.Ng.MasterEntities
{
    public abstract class MongoMasterEntityRepositoryBase : MongoDbRepository<NgDbContext, MasterEntity, Guid>
    {
        public MongoMasterEntityRepositoryBase(IMongoDbContextProvider<NgDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? name = null,
            int? costMin = null,
            int? costMax = null,
            string? address = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name, costMin, costMax, address);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<MasterEntity>> GetListAsync(
            string? filterText = null,
            string? name = null,
            int? costMin = null,
            int? costMax = null,
            string? address = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name, costMin, costMax, address);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? MasterEntityConsts.GetDefaultSorting(false) : sorting);
            return await query.As<IMongoQueryable<MasterEntity>>()
                .PageBy<MasterEntity, IMongoQueryable<MasterEntity>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            int? costMin = null,
            int? costMax = null,
            string? address = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name, costMin, costMax, address);
            return await query.As<IMongoQueryable<MasterEntity>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<MasterEntity> ApplyFilter(
            IQueryable<MasterEntity> query,
            string? filterText = null,
            string? name = null,
            int? costMin = null,
            int? costMax = null,
            string? address = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name!.Contains(filterText!) || e.Address!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(costMin.HasValue, e => e.Cost >= costMin!.Value)
                    .WhereIf(costMax.HasValue, e => e.Cost <= costMax!.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address));
        }
    }
}