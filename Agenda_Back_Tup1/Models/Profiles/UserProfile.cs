using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using AutoMapper;

namespace Agenda_Back_Tup1.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();

            CreateMap<User, UserDTOCreacion>();
            CreateMap<UserDTOCreacion, User>();

            CreateMap<User, UserModificacionDataDTO>();
            CreateMap<UserModificacionDataDTO, User>();
        }
    }
}
