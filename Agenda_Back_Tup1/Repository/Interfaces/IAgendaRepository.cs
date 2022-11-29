using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;

namespace Agenda_Back_Tup1.Repository.Interfaces
{
    public interface IAgendaRepository
    {
        public List<Agenda> GetListAgendas();
        public Agenda GetAgendaById(int agendaId);
        public int CreateAgenda(Agenda agenda);
        public void DeleteAgenda(Agenda agenda);
        public void UpdateAgenda(Agenda agenda);
    }
}
