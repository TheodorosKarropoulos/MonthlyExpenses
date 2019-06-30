using AutoMapper;

namespace MonthlyExpenses.Api
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            this.CreateMap<Dto.Category, Model.Category>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name));

            this.CreateMap<Model.Category, Dto.Category>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name));

            this.CreateMap<Database.Category, Model.Category>()
                .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name));
        }
    }
}
