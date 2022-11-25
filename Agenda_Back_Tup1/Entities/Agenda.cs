using Agenda_Back_Tup.Entities;

namespace Agenda_Back_Tup1.Entities
{
    public class Agenda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }

        public IEnumerable<Contacto> Contactos { get; set; } //relacion 1 a muchos contactos

        public IEnumerable<AgendasUsers> AgendasUsers { get; set; }
        //ienum de user
    }
}
