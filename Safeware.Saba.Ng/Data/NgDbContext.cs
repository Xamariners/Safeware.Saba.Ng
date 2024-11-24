using Safeware.Saba.Ng.MasterEntities;
using MongoDB.Driver;
using Volo.Abp.Data;
using Volo.Abp.MongoDB;
using Safeware.Saba.Ng.Entities.Books;

namespace Safeware.Saba.Ng.Data;

[ConnectionStringName("Default")]
public class NgDbContext : AbpMongoDbContext
{
    public IMongoCollection<MasterEntity> MasterEntities => Collection<MasterEntity>();
    /* Add mongo collections here. Example:
     * public IMongoCollection<Question> Questions => Collection<Question>();
     */

    public IMongoCollection<Book> Books => Collection<Book>();

    protected override void CreateModel(IMongoModelBuilder modelBuilder)
    {
        base.CreateModel(modelBuilder);

        //builder.Entity<YourEntity>(b =>
        //{
        //    //...
        //});
    }
}