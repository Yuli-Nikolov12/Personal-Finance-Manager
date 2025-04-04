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

            CreateMap<Category, CategoryDTO>();

            CreateMap<Budget, BudgetDTO>();

            CreateMap<Report, ReportDTO>();

            CreateMap<Currency, CurrencyDTO>();
        }
    }
}
