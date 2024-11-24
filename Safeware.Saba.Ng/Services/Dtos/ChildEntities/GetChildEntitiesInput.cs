using Volo.Abp.Application.Dtos;
using System;

namespace Safeware.Saba.Ng.ChildEntities
{
    public abstract class GetChildEntitiesInputBase : PagedAndSortedResultRequestDto
    {
        public Guid? MasterEntityId { get; set; }

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public bool? Enabled { get; set; }
        public Guid? BookId { get; set; }

        public GetChildEntitiesInputBase()
        {

        }
    }
}