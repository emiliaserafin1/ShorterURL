using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
