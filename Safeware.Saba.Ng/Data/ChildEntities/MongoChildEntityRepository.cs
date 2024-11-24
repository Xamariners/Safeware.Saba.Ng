using Book;
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

namespace Safeware.Saba.Ng.ChildEntities
{
    public abstract class MongoChildEntityRepositoryBase : MongoDbRepository<NgDbContext, ChildEntity, Guid>
    {
        public MongoChildEntityRepositoryBase(IMongoDbContextProvider<NgDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task<List<ChildEntity>> GetListByMasterEntityIdAsync(
                   Guid masterEntityId,
                   string? sorting = null,
                   int maxResultCount = int.MaxValue,
                   int skipCount = 0,
                   CancellationToken cancellationToken = default)
        {
            IQueryable<ChildEntity> query = (await GetMongoQueryableAsync(cancellationToken)).Where(x => x.MasterEntityId == masterEntityId);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ChildEntityConsts.GetDefaultSorting(false) : sorting);

            return await query
                .As<IMongoQueryable<ChildEntity>>()
                .PageBy<ChildEntity, IMongoQueryable<ChildEntity>>(skipCount, maxResultCount)
                .ToListAsync(cancellationToken);
        }

        public virtual async Task<long> GetCountByMasterEntityIdAsync(Guid masterEntityId, CancellationToken cancellationToken = default)
        {
            return await (await GetMongoQueryableAsync(cancellationToken)).Where(x => x.MasterEntityId == masterEntityId).CountAsync(cancellationToken);
        }

        public virtual async Task<List<ChildEntityWithNavigationProperties>> GetListWithNavigationPropertiesByMasterEntityIdAsync(
    Guid masterEntityId,
    string? sorting = null,
    int maxResultCount = int.MaxValue,
    int skipCount = 0,
    CancellationToken cancellationToken = default)
        {
            var query = (await GetMongoQueryableAsync(cancellationToken)).Where(x => x.MasterEntityId == masterEntityId);
            var childEntities = await query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ChildEntityConsts.GetDefaultSorting(false) : sorting.Split('.').Last())
                .As<IMongoQueryable<ChildEntity>>()
                .PageBy<ChildEntity, IMongoQueryable<ChildEntity>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            var dbContext = await GetDbContextAsync(cancellationToken);
            return childEntities.Select(s => new ChildEntityWithNavigationProperties
            {
                ChildEntity = s,
                Book = ApplyDataFilters<IMongoQueryable<Book>, Book>(dbContext.Collection<Book>().AsQueryable()).FirstOrDefault(e => e.Id == s.BookId),

            }).ToList();
        }

        public virtual async Task<ChildEntityWithNavigationProperties> GetWithNavigationPropertiesAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var childEntity = await (await GetMongoQueryableAsync(cancellationToken))
                .FirstOrDefaultAsync(e => e.Id == id, GetCancellationToken(cancellationToken));

            var book = await (await GetMongoQueryableAsync<Book>(cancellationToken)).FirstOrDefaultAsync(e => e.Id == childEntity.BookId, cancellationToken: cancellationToken);

            return new ChildEntityWithNavigationProperties
            {
                ChildEntity = childEntity,
                Book = book,

            };
        }

        public virtual async Task<List<ChildEntityWithNavigationProperties>> GetListWithNavigationPropertiesAsync(
            string? filterText = null,
            string? name = null,
            bool? enabled = null,
            Guid? bookId = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name, enabled, bookId);
            var childEntities = await query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ChildEntityConsts.GetDefaultSorting(false) : sorting.Split('.').Last())
                .As<IMongoQueryable<ChildEntity>>()
                .PageBy<ChildEntity, IMongoQueryable<ChildEntity>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));

            var dbContext = await GetDbContextAsync(cancellationToken);
            return childEntities.Select(s => new ChildEntityWithNavigationProperties
            {
                ChildEntity = s,
                Book = ApplyDataFilters<IMongoQueryable<Book>, Book>(dbContext.Collection<Book>().AsQueryable()).FirstOrDefault(e => e.Id == s.BookId),

            }).ToList();
        }

        public virtual async Task<List<ChildEntity>> GetListAsync(
            string? filterText = null,
            string? name = null,
            bool? enabled = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name, enabled);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ChildEntityConsts.GetDefaultSorting(false) : sorting);
            return await query.As<IMongoQueryable<ChildEntity>>()
                .PageBy<ChildEntity, IMongoQueryable<ChildEntity>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? name = null,
            bool? enabled = null,
            Guid? bookId = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, name, enabled, bookId);
            return await query.As<IMongoQueryable<ChildEntity>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ChildEntity> ApplyFilter(
            IQueryable<ChildEntity> query,
            string? filterText = null,
            string? name = null,
            bool? enabled = null,
            Guid? bookId = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(enabled.HasValue, e => e.Enabled == enabled)
                    .WhereIf(bookId != null && bookId != Guid.Empty, e => e.BookId == bookId);
        }
    }
}