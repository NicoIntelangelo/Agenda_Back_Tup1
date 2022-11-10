using Agenda_Back_Tup1.Data;
using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Repository.Interfaces;

namespace Agenda_Back_Tup1.Repository.Implementatios
{
    public class ContactoRepository : IContactoRepository
    {
        private readonly AplicationDbContext _context;

        public ContactoRepository(AplicationDbContext context)
        {
            _context = context;
        }

        public List<Contacto> GetListContactos(int agendaId)
        {
            return _context.Contactos.Where(c => c.AgendaId == agendaId).ToList();

        }

        public Contacto GetContacto(int id)
        {
            return _context.Contactos.Find(id);

        }


    }
}
