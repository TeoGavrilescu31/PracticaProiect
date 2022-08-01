using AutoMapper;
using PracticaProiect.Entities;

namespace PracticaProiect.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, ExternalModels.MenuDTO>();
            CreateMap<ExternalModels.MenuDTO, Menu>();

            CreateMap<Category, ExternalModels.CategoryDTO>();
            CreateMap<ExternalModels.CategoryDTO, Category>();
        }
    }
}
