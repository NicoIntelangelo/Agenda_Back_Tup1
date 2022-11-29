using Agenda_Back_Tup.Entities;
using Agenda_Back_Tup1.Models.DTO;

namespace Agenda_Back_Tup1.Repository.Interfaces
{
    public interface IAgendaUserRepository
    {
        public List<AgendasUsers> GetAgendasUser(int userId);
        public void addAgendaUser(int userId, int AgendaId);
        public void DeleteAgendaUser(int agendaId);
    }
}
