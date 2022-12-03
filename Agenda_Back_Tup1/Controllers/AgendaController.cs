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


        [HttpGet] 
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

        
        [HttpPost]//("newagenda")
        public IActionResult CreateAgenda(AgendaCreacionDTO agendaCreacionDto)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                var agenda = _mapper.Map<Agenda>(agendaCreacionDto);

                int id = _agendaRepository.CreateAgenda(agenda); //la fun createagenda retorna el val del id creado


                _agendaUserRepository.addAgendaUser(userId, id); 

                return Created("Created", id);

            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPut("{agendaid}")]
        public IActionResult AddAgendaUser(int agendaid)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);


                _agendaUserRepository.addAgendaUser(userId,agendaid);

                return Created("Created", agendaid);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAgenda(int id)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

                var listAgenda = _agendaUserRepository.GetAgendasUser(userId);

                List<Agenda> listAgendas = new List<Agenda>();

                var agenda = _agendaRepository.GetAgendaById(id);

                foreach (var agendaUser in listAgenda)
                {
                    if (agendaUser.AgendaId == id)
                    {

                        if (agenda == null)
                        {
                            return NotFound();
                        }

                        _agendaUserRepository.DeleteAgendaUser(id);//no elimina la agenda sino que elimina todas las relaciones con los dueños, la agenda sigue existiendo
                        //_agendaRepository.DeleteAgenda(agenda);

                        return NoContent();
                    }

                }
                return Unauthorized();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut("edit/{id}")] 
        public IActionResult EditAgenda(int id, AgendaCreacionDTO agendaDto)
        {
            try
            {
                int userId = Int32.Parse(HttpContext.User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value); 

                var listAgenda = _agendaUserRepository.GetAgendasUser(userId); 

                List<Agenda> listAgendas = new List<Agenda>(); 

                var agenda = _mapper.Map<Agenda>(agendaDto);
                
                foreach (var agendaUser in listAgenda) 
                {
                   if(agendaUser.AgendaId == id)
                    {

                        if (id != agenda.Id)
                        {
                            return NotFound();
                        }
                        
                        var agendaItem = _agendaRepository.GetAgendaById(id);

                        if (agendaItem == null)
                        {
                            return NotFound();
                        }

                        _agendaRepository.UpdateAgenda(agenda);

                        var agendaModificada = _agendaRepository.GetAgendaById(id);

                        var agendaModificadaDto = _mapper.Map<AgendaDTO>(agendaModificada);

                        return Ok(agendaModificadaDto);
                    }
                }
                return Unauthorized();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
