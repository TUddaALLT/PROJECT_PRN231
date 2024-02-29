using System.ComponentModel.DataAnnotations;

namespace PROJECT_PRN231.Models.Mail
{
    public class OTPResponse
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        //[Required]
        //public string OTPCode { get; set; }
    }
}
