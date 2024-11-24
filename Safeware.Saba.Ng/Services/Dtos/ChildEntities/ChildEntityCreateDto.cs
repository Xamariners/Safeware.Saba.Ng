using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Safeware.Saba.Ng.ChildEntities
{
    public abstract class ChildEntityCreateDtoBase
    {
        public Guid MasterEntityId { get; set; }
        public string? Name { get; set; }
        public bool Enabled { get; set; }
        public Guid? BookId { get; set; }
    }
}