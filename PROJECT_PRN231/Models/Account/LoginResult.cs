using System.ComponentModel.DataAnnotations;

namespace PROJECT_PRN231.Models.Account
{
    public class LoginResult
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
