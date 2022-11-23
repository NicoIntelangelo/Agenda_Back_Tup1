using Agenda_Back_Tup.Entities;
using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using AutoMapper;

namespace Agenda_Back_Tup1.Models.Profiles
{
    public class AgendaUserProfile : Profile
    {
        public AgendaUserProfile()
        {
            CreateMap<AgendasUsers, AgendaUserDTO>();
            CreateMap<AgendaUserDTO, AgendasUsers>();
        }
    }
}
