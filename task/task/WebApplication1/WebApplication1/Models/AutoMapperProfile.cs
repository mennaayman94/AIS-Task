using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class AccountMapperProfile : Profile
    {
        public AccountMapperProfile()
        {
            //CreateMap<Account, AccountDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CustomerName));

            //CreateMap<AccountsCategory, CategoryDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CategoryName));

            //CreateMap<AccountsType, TypeDTO>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TypeName));
            Mapper.CreateMap<Account, AccountDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.AccountsCategory))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.AccountsType));
            Mapper.CreateMap<AddAcountDTO, Account>();
            Mapper.CreateMap<Account, AddAcountDTO>();
            Mapper.CreateMap<AddCategoryDTO, AccountsCategory>();
            Mapper.CreateMap<AccountsCategory, AddCategoryDTO>();
            Mapper.CreateMap<AccountDTO, Account>();
            Mapper.CreateMap<AccountsCategory, CategoryDTO>();
            Mapper.CreateMap<CategoryDTO, AccountsCategory>();
            Mapper.CreateMap<AccountsType, TypeDTO>();
            Mapper.CreateMap<TypeDTO, AccountsType>();
        }
    }
}