using System.ComponentModel.DataAnnotations;

namespace PROJECT_PRN231.Models.Mail
{
    public class SendOTP
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
    }
}
