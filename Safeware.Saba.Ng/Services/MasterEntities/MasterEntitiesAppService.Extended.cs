using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Safeware.Saba.Ng.Permissions;
using Safeware.Saba.Ng.MasterEntities;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Safeware.Saba.Ng.Shared;

namespace Safeware.Saba.Ng.MasterEntities
{
    public class MasterEntitiesAppService : MasterEntitiesAppServiceBase, IMasterEntitiesAppService
    {
        //<suite-custom-code-autogenerated>
        public MasterEntitiesAppService(IMasterEntityRepository masterEntityRepository, MasterEntityManager masterEntityManager, IDistributedCache<MasterEntityDownloadTokenCacheItem, string> downloadTokenCache)
            : base(masterEntityRepository, masterEntityManager, downloadTokenCache)
        {
        }
        //</suite-custom-code-autogenerated>

        //Write your custom code...
    }
}