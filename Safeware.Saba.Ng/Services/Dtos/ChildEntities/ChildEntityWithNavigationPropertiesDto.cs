using Book;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Safeware.Saba.Ng.ChildEntities
{
    public abstract class ChildEntityWithNavigationPropertiesDtoBase
    {
        public ChildEntityDto ChildEntity { get; set; } = null!;

        public BookDto Book { get; set; } = null!;

    }
}