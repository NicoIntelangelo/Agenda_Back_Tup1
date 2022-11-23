using Agenda_Back_Tup1.Entities;

namespace Agenda_Back_Tup1.Models.DTO
{
    public class AgendaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public IEnumerable<Contacto> Contactos { get; set; }
    }
}
