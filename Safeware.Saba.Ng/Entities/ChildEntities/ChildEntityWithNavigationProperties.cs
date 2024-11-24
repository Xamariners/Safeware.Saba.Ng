using Book;

using System;
using System.Collections.Generic;

namespace Safeware.Saba.Ng.ChildEntities
{
    public abstract class ChildEntityWithNavigationPropertiesBase
    {
        public ChildEntity ChildEntity { get; set; } = null!;

        public Book Book { get; set; } = null!;
        

        
    }
}