using Book;
using Safeware.Saba.Ng.ChildEntities;
using System;
using Safeware.Saba.Ng.Shared;
using Volo.Abp.AutoMapper;
using Safeware.Saba.Ng.MasterEntities;
using AutoMapper;
using Safeware.Saba.Ng.Entities.Books;
using Safeware.Saba.Ng.Services.Dtos.Books;

namespace Safeware.Saba.Ng.ObjectMapping;

public class NgAutoMapperProfile : Profile
{
    public NgAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<BookDto, CreateUpdateBookDto>();
        /* Create your AutoMapper object mappings here */

        CreateMap<MasterEntity, MasterEntityDto>();
        CreateMap<MasterEntity, MasterEntityExcelDto>();

        CreateMap<ChildEntity, ChildEntityDto>();
        CreateMap<ChildEntityWithNavigationProperties, ChildEntityWithNavigationPropertiesDto>();
        CreateMap<Book, LookupDto<Guid>>().ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Name));
    }
}