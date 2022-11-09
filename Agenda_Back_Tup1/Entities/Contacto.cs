using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_Back_Tup1.Entities
{
    public class Contacto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        [ForeignKey("AgendaId")]
        public int AgendaId { get; set; } //relacion muchos contactos a 1 agenda
        public Agenda Agenda { get; set; }
    }
}
