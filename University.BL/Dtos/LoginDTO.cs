using System.ComponentModel.DataAnnotations;

namespace University.BL.Dtos
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
