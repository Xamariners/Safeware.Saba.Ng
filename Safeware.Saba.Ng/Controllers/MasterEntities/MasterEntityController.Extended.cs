using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Safeware.Saba.Ng.MasterEntities;

namespace Safeware.Saba.Ng.MasterEntities
{
    [RemoteService]
    [Area("app")]
    [ControllerName("MasterEntity")]
    [Route("api/app/master-entities")]

    public class MasterEntityController : MasterEntityControllerBase, IMasterEntitiesAppService
    {
        public MasterEntityController(IMasterEntitiesAppService masterEntitiesAppService) : base(masterEntitiesAppService)
        {
        }
    }
}