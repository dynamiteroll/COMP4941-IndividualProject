

using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Users
    {
        public int UserID { get; set; }
        
        public string? Username { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
