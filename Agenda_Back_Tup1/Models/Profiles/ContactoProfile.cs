using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using AutoMapper;

namespace Agenda_Back_Tup1.Models.Profiles
{
    public class ContactoProfile: Profile
    {
        public ContactoProfile()
        {
            CreateMap<Contacto, ContactoDTO>();  //mapeo de la entidad contacto al dto y viceversa
            CreateMap<ContactoDTO, Contacto>();
        }
    }
}
