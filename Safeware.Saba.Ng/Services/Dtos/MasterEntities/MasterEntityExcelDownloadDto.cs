using Volo.Abp.Application.Dtos;
using System;

namespace Safeware.Saba.Ng.MasterEntities
{
    public abstract class MasterEntityExcelDownloadDtoBase
    {
        public string DownloadToken { get; set; } = null!;

        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public int? CostMin { get; set; }
        public int? CostMax { get; set; }
        public string? Address { get; set; }

        public MasterEntityExcelDownloadDtoBase()
        {

        }
    }
}