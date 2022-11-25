using Agenda_Back_Tup.Entities;

namespace Agenda_Back_Tup1.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Password { get; set; }
        public IEnumerable<AgendasUsers> AgendasUsers { get; set; }
        // ienum de agenda
    }
}
