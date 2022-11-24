using Agenda_Back_Tup1.Entities;
using Agenda_Back_Tup1.Models.DTO;
using Agenda_Back_Tup1.Repository.Implementatios;
using Agenda_Back_Tup1.Repository.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agenda_Back_Tup1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]//******* para que tengamos que tener un token valido para acceder
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserController(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        
        [HttpGet("getallusers")]
        public IActionResult GetuUsers()
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
        

        [HttpGet("getuser/{id}")]
        public IActionResult GetUser(int id)
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
        
        //[HttpPost("newuser")]
        //public IActionResult PostUser(UserDTOCreacion userDtoCreacion)
        //{
        //    try
        //    {
                
        //        var user = _mapper.Map<User>(userDtoCreacion);


        //        var userItem = _userRepository.AddUser(user);

        //        var userItemDto = _mapper.Map<UserDTO>(userItem);

        //        return Created("Created", userItemDto); ///*************
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
    }
}
