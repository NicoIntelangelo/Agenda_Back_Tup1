using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using AutoMapper;

namespace Agenda_Back_Tup1.Models.Profiles
{
    public class AgendaProfile : Profile
    {
        public AgendaProfile()
        {
            CreateMap<Agenda, AgendaDTO>();
            CreateMap<AgendaDTO, Agenda>();

            CreateMap<Agenda, AgendaCreacionDTO>();
            CreateMap<AgendaCreacionDTO, Agenda>();
        }
    }
}
