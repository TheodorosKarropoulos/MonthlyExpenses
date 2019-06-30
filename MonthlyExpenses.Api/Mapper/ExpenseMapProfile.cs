using AutoMapper;

namespace MonthlyExpenses.Api
{
    public class ExpenseMapProfile : Profile
    {
        public ExpenseMapProfile()
        {
            this.CreateMap<Dto.Expense, Model.Expense>()
                .ForMember(dest => dest.Amount, map => map.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Month, map => map.MapFrom(src => src.Month))
                .ForMember(dest => dest.Year, map => map.MapFrom(src => src.Year))
                .ForMember(dest => dest.Status, map => map.MapFrom(src => src.Status));

            this.CreateMap<Model.Expense, Dto.Expense>()
                .ForMember(dest => dest.Amount, map => map.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Month, map => map.MapFrom(src => src.Month))
                .ForMember(dest => dest.Year, map => map.MapFrom(src => src.Year))
                .ForMember(dest => dest.Status, map => map.MapFrom(src => src.Status))
                .ForMember(dest => dest.CategoryId, map => map.MapFrom(src => src.Category.Id));

            this.CreateMap<Model.Expense, Database.Expense>()
                .ForMember(dest => dest.Status, map => map.MapFrom(src => src.Status))
                .ForMember(dest => dest.Amount, map => map.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Month, map => map.MapFrom(src => src.Month))
                .ForMember(dest => dest.Year, map => map.MapFrom(src => src.Year))
                .ForMember(dest => dest.CategoryId, map => map.MapFrom(src => src.Category.Id));

            this.CreateMap<Database.Expense, Model.Expense>()
                .ForMember(dest => dest.Status, map => map.MapFrom(src => src.Status))
                .ForMember(dest => dest.Amount, map => map.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Month, map => map.MapFrom(src => src.Month))
                .ForMember(dest => dest.Year, map => map.MapFrom(src => src.Year))
                .ForMember(x => x.Id, x => x.Ignore());
        }
    }
}
