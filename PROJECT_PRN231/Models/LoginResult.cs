using System.ComponentModel.DataAnnotations;

namespace PROJECT_PRN231.Models
{
    public class LoginResult
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
