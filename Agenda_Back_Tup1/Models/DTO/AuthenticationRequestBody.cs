using System.ComponentModel.DataAnnotations;

namespace Agenda_Back_Tup1.Models.DTO
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
