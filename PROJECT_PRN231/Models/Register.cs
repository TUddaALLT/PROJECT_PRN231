using System.ComponentModel.DataAnnotations;

namespace PROJECT_PRN231.Models
{
    public class Register
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
