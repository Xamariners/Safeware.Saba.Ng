using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Safeware.Saba.Ng.Data;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace Safeware.Saba.Ng.ChildEntities
{
    public class MongoChildEntityRepository : MongoChildEntityRepositoryBase, IChildEntityRepository
    {
        public MongoChildEntityRepository(IMongoDbContextProvider<NgDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        //Write your custom code...
    }
}