using Agenda_Back_Tup1.Data;
using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using Agenda_Back_Tup1.Repository.Interfaces;
using AutoMapper;

namespace Agenda_Back_Tup1.Repository.Implementatios
{
    public class AgendaRepository : IAgendaRepository

    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        public AgendaRepository(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Agenda> GetListAgendas()
        {
            return _context.Agendas.ToList();

        }

        public Agenda GetAgendaById(int agendaId)
        {
            return _context.Agendas.SingleOrDefault(a => a.Id == agendaId);

        }

        public int CreateAgenda(Agenda agenda)
        {
            _context.Agendas.Add(agenda);
            
            _context.SaveChanges();
            
            var id = agenda.Id;
            
            return id;
        }

        public void DeleteAgenda(Agenda agenda)
        {
            _context.Agendas.Remove(agenda);
            _context.SaveChanges();
        }
        public void UpdateAgenda(Agenda agenda)
        {
            var agendaItem = _context.Agendas.FirstOrDefault(a => a.Id == agenda.Id);

            if (agendaItem != null)
            {
                agendaItem.Nombre = agenda.Nombre;

                _context.SaveChanges();
            }
        }


    }
}
