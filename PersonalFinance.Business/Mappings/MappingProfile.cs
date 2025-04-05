using AutoMapper;
using PersonalFinance.Business.DTOs;
using PersonalFinance.Business.Entities;

namespace PersonalFinance.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Transaction, TransactionDTO>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency));

            CreateMap<TransactionDTO, Transaction>()
                .ForMember(dest=>dest.CurrencyId, opt => opt.MapFrom(src => src.Currency.CurrencyId ))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.CategoryId))
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.Currency, opt => opt.Ignore())
                .ForMember(dest => dest.TransactionId, opt => opt.Ignore());

            CreateMap<Category, CategoryDTO>();

            CreateMap<CategoryDTO, Category>();

            CreateMap<Budget, BudgetDTO>();

            CreateMap<Report, ReportDTO>();

            CreateMap<Currency, CurrencyDTO>();

            CreateMap<CurrencyDTO, Currency>();
        }
    }
}
