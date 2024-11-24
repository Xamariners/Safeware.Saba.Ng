using System;

namespace Safeware.Saba.Ng.MasterEntities
{
    public abstract class MasterEntityExcelDtoBase
    {
        public string? Name { get; set; }
        public int Cost { get; set; }
        public string Address { get; set; } = null!;
    }
}