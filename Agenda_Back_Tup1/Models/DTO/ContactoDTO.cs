using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda_Back_Tup1.Models.DTO
{
    public class ContactoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public int AgendaId { get; set; } 
    }
}
