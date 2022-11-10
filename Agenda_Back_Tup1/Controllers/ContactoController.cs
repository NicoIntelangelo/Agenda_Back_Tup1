using Agenda_Back_Tup1.Models.DTO;
using Agenda_Back_Tup1.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Back_Tup1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactoRepository _contactoRepository;

        public ContactoController(IMapper mapper, IContactoRepository contactoRepository) //inyeccion del automapper
        {
            _mapper = mapper;
            _contactoRepository = contactoRepository;
        }

        
        [HttpGet("getByAgenda/{agendaId}")]
        public IActionResult Get(int agendaId)
        {
            try
            {
                var listaContactos = _contactoRepository.GetListContactos(agendaId);

                var listaContactosDTO = _mapper.Map<IEnumerable<ContactoDTO>>(listaContactos);

                return Ok(listaContactosDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get2(int id)
        {
            try { 
            //{
            //    if (str == "contacto")
            //    {
            //    }
                   
                    var contacto = _contactoRepository.GetContacto(id); 

                    if (contacto == null)
                    {
                        return NotFound();
                    }

                    var contactoDto = _mapper.Map<ContactoDTO>(contacto); // mapea la mascota que saco de la db(entidad), en el <MascotaDto>

                    return Ok(contactoDto);
                //else
                //{
                //    return BadRequest("debe tener 'conctacto/' antes de el id");
                //}
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}
