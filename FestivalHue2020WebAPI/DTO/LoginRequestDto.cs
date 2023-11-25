using System.ComponentModel.DataAnnotations;

namespace FestivalHue2020WebAPI.DTO
{
    public class LoginRequest 
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
