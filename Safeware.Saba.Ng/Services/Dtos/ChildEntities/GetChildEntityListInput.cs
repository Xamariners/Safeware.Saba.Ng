using Volo.Abp.Application.Dtos;
using System;

namespace Safeware.Saba.Ng.ChildEntities
{
    public class GetChildEntityListInput : PagedAndSortedResultRequestDto
    {
        public Guid MasterEntityId { get; set; }
    }
}