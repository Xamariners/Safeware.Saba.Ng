using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Safeware.Saba.Ng.MasterEntities
{
    public abstract class MasterEntityManagerBase : DomainService
    {
        protected IMasterEntityRepository _masterEntityRepository;

        public MasterEntityManagerBase(IMasterEntityRepository masterEntityRepository)
        {
            _masterEntityRepository = masterEntityRepository;
        }

        public virtual async Task<MasterEntity> CreateAsync(
        int cost, string address, string? name = null)
        {
            Check.NotNullOrWhiteSpace(address, nameof(address));

            var masterEntity = new MasterEntity(
             GuidGenerator.Create(),
             cost, address, name
             );

            return await _masterEntityRepository.InsertAsync(masterEntity);
        }

        public virtual async Task<MasterEntity> UpdateAsync(
            Guid id,
            int cost, string address, string? name = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(address, nameof(address));

            var masterEntity = await _masterEntityRepository.GetAsync(id);

            masterEntity.Cost = cost;
            masterEntity.Address = address;
            masterEntity.Name = name;

            masterEntity.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _masterEntityRepository.UpdateAsync(masterEntity);
        }

    }
}