using Agenda_Back_Tup1.Entities;

namespace Agenda_Back_Tup1.Repository.Interfaces
{
    public interface IContactoRepository
    {
        List<Contacto> GetListContactos(int agendaId);
        Contacto GetContacto(int id);
        public void DeleteContact(Contacto contacto);
        public Contacto AddContacto(Contacto contacto);
        public void UpdateContact(Contacto contacto);
    }
}
