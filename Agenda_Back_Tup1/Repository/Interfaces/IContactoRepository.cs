using Agenda_Back_Tup1.Entities;

namespace Agenda_Back_Tup1.Repository.Interfaces
{
    public interface IContactoRepository
    {
        //List<Contacto> GetListContactos();
        List<Contacto> GetListContactos(int agendaId);
        Contacto GetContacto(int id);
        //void DeleteContacto(Contacto contacto);
        public Contacto AddContacto(Contacto contacto);
        //void UpdateContacto(Contacto contacto);
    }
}
