using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using Agenda_Back_Tup1.Repository.Implementatios;
using Agenda_Back_Tup1.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Agenda_Back_Tup1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AgendaController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAgendaRepository _agendaRepository;
        private readonly IAgendaUserRepository _agendaUserRepository;

        public AgendaController(IMapper mapper, IAgendaRepository agendaRepository, IAgendaUserRepository agendaUserRepository)
        {
            _mapper = mapper;
            _agendaRepository = agendaRepository;
            _agendaUserRepository = agendaUserRepository;
        }


        [HttpGet("getall")]
        public IActionResult GetAgendas()
        {
            try
            {
                var listAgenda = _agendaRepository.GetListAgendas();

                var listAgendaDto = _mapper.Map<IEnumerable<AgendaDTO>>(listAgenda);

                return Ok(listAgendaDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getAgendas")]
        public IActionResult GetAgendasOfUser()
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value); // toma el id del usuario desde el token

                var listAgenda = _agendaUserRepository.GetAgendasUser(userId); //trae todas las ajendas las cuales el user es dueño

                List<Agenda> listAgendas = new List<Agenda>(); //crea una lista de objetos ajenda

                foreach (var agendaUser in listAgenda) //para cada relacion agenda/user de la listAgenda
                {
                    var agenda =  _agendaRepository.GetAgendaById(agendaUser.AgendaId); //busca la agenda tomanddo el valor AgendaId de la relacion agenda/user

                    listAgendas.Add(agenda);// agrega esa agenda encontrada a la lista de agendass
                }
                
                
                var listAgendasDto = _mapper.Map<IEnumerable<AgendaDTO>>(listAgendas);// transforma cada agenda en un AgendaDTO

                return Ok(listAgendasDto); //retorna la lista de las agendasDTO
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPost("newagenda")]
        public IActionResult CreateAgenda(AgendaCreacionDTO agendaCreacionDto)
        {
            try
            {
                int id = _agendaRepository.CreateAgenda(agendaCreacionDto); //la fun createagenda retorna el val del id creado

                int userId = Int32.Parse(HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                _agendaUserRepository.addAgendaUser(userId, id); 

                return Created("Created", id);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
           
        }
    }
}
