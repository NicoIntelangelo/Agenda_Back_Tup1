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

        public int CreateAgenda(AgendaCreacionDTO agendaDto)
        {
            var agenda = _mapper.Map<Agenda>(agendaDto);
            
            _context.Agendas.Add(agenda);
            
            _context.SaveChanges();
            
            var id = agenda.Id;
            
            return id;
        }
        
    }
}
