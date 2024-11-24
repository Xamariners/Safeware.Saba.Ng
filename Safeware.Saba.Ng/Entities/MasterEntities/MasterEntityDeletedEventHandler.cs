using Safeware.Saba.Ng.ChildEntities;

using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;

namespace Safeware.Saba.Ng.MasterEntities;

public class MasterEntityDeletedEventHandler : ILocalEventHandler<EntityDeletedEventData<MasterEntity>>, ITransientDependency
{
    private readonly IChildEntityRepository _childEntityRepository;

    public MasterEntityDeletedEventHandler(IChildEntityRepository childEntityRepository)
    {
        _childEntityRepository = childEntityRepository;

    }

    public async Task HandleEventAsync(EntityDeletedEventData<MasterEntity> eventData)
    {
        if (eventData.Entity is not ISoftDelete softDeletedEntity)
        {
            return;
        }

        if (!softDeletedEntity.IsDeleted)
        {
            return;
        }

        try
        {
            await _childEntityRepository.DeleteManyAsync(await _childEntityRepository.GetListByMasterEntityIdAsync(eventData.Entity.Id));

        }
        catch
        {
            //...
        }
    }
}