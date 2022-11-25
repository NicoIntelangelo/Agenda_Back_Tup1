using Agenda_Back_Tup1.Data;
using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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
        public Contacto AddContacto(Contacto contacto)
        {
            _context.Contactos.Add(contacto);
            _context.SaveChanges();
            return contacto;
        }

        public void DeleteContact(Contacto contacto)
        { 
            _context.Contactos.Remove(contacto);
            _context.SaveChanges();
        }

        public void UpdateContact(Contacto contacto)
        {
            var contactItem = _context.Contactos.FirstOrDefault(x => x.Id == contacto.Id);

            if (contactItem != null)
            {
                contactItem.Nombre = contacto.Nombre;
                contactItem.Telefono = contacto.Telefono;
                contactItem.Direccion = contacto.Direccion;
                contactItem.Mail = contacto.Mail;

                _context.SaveChanges();
            }

        }



    }
}
