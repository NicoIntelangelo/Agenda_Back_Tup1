using Agenda_Back_Tup1.Entities;

namespace Agenda_Back_Tup.Entities
{//relacion de muchos a muchos de users agendas
    public class AgendasUsers
    {
        //public int Id { get; set; } 
        
        public int AgendaId { get; set; }
        public Agenda Agenda { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
        
    }
}
