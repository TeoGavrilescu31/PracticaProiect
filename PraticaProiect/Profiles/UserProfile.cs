using AutoMapper;
using PracticaProiect.Entities;

namespace PracticaProiect.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, ExternalModels.UserDTO>();
            CreateMap<ExternalModels.UserDTO, User>();
        }
    }
}
