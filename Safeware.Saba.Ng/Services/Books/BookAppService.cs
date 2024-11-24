using System;
using Safeware.Saba.Ng.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Safeware.Saba.Ng.Services.Dtos.Books;
using Safeware.Saba.Ng.Entities.Books;

namespace Safeware.Saba.Ng.Services.Books;

public class BookAppService :
    CrudAppService<
        Book, //The Book entity
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>, //Used to create/update a book
    IBookAppService //implement the IBookAppService
{
    public BookAppService(IRepository<Book, Guid> repository)
        : base(repository)
    {
        GetPolicyName = NgPermissions.Books.Default;
        GetListPolicyName = NgPermissions.Books.Default;
        CreatePolicyName = NgPermissions.Books.Create;
        UpdatePolicyName = NgPermissions.Books.Edit;
        DeletePolicyName = NgPermissions.Books.Delete;
    }
}