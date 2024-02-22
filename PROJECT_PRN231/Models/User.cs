using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT_PRN231.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
    }
}
