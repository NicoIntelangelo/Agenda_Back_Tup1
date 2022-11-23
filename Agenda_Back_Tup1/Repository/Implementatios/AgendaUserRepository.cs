using Agenda_Back_Tup.Entities;
using Agenda_Back_Tup1.Data;
using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using Agenda_Back_Tup1.Repository.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace Agenda_Back_Tup1.Repository.Implementatios
{
    public class AgendaUserRepository : IAgendaUserRepository
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;
        public AgendaUserRepository(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AgendasUsers> GetAgendasUser(int userId)
        {
            return _context.AgendasUsers.Where(au => au.UserId == userId).ToList();

        }
        public void addAgendaUser (int userId , int AgendaId)//(AgendaUserDTO agendaUserDto)
        {
            AgendasUsers agendaUser = new AgendasUsers();
            {
                agendaUser.AgendaId = AgendaId;
                agendaUser.UserId = userId;

            };

            _context.AgendasUsers.Add(agendaUser);
            
            _context.SaveChanges();


        }

    }
}
