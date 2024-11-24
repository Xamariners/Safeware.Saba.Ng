using Asp.Versioning;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Safeware.Saba.Ng.ChildEntities;

namespace Safeware.Saba.Ng.ChildEntities
{
    [RemoteService]
    [Area("app")]
    [ControllerName("ChildEntity")]
    [Route("api/app/child-entities")]

    public class ChildEntityController : ChildEntityControllerBase, IChildEntitiesAppService
    {
        public ChildEntityController(IChildEntitiesAppService childEntitiesAppService) : base(childEntitiesAppService)
        {
        }
    }
}