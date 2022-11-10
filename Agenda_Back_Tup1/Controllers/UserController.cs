using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using Agenda_Back_Tup1.Repository.Implementatios;
using Agenda_Back_Tup1.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Back_Tup1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var listUser = _userRepository.GetListUser();

                var listUserDto = _mapper.Map<IEnumerable<UserDTO>>(listUser); 

                return Ok(listUserDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
        [HttpPost]
        public IActionResult Post(UserDTOCreacion userDtoCreacion)
        {
            try
            {
                //int nico = Int32.Parse(HttpContext.User.Claims.SingleOrDefault(c => c.Type.Contains("sub")).Value);
                
                var user = _mapper.Map<User>(userDtoCreacion);


                var userItem = _userRepository.AddUser(user);

                var userItemDto = _mapper.Map<UserDTO>(userItem);

                return CreatedAtAction("Get", new { id = userItemDto.Id }, userItemDto); ///*************
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _userRepository.GetUser(id);

                if (user == null)
                {
                    return NotFound();
                }

                var userDto = _mapper.Map<UserDTO>(user); 

                return Ok(userDto);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
