﻿using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Safeware.Saba.Ng.Services.Dtos.Books;
using Safeware.Saba.Ng.Entities.Books;

namespace Safeware.Saba.Ng.Services.Books;

public interface IBookAppService :
    ICrudAppService< //Defines CRUD methods
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto> //Used to create/update a book
{

}